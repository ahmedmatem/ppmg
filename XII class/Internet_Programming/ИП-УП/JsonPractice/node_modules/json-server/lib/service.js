import inflection from 'inflection';
import { Low } from 'lowdb';
import sortOn from 'sort-on';
import { matchesWhere } from "./matches-where.js";
import { paginate } from "./paginate.js";
import { randomId } from "./random-id.js";
export function isItem(obj) {
    return typeof obj === 'object' && obj !== null && !Array.isArray(obj);
}
function ensureArray(arg = []) {
    return Array.isArray(arg) ? arg : [arg];
}
function embed(db, name, item, related) {
    if (inflection.singularize(related) === related) {
        const relatedData = db.data[inflection.pluralize(related)];
        if (!relatedData) {
            return item;
        }
        const foreignKey = `${related}Id`;
        const relatedItem = relatedData.find((relatedItem) => {
            return relatedItem['id'] === item[foreignKey];
        });
        return { ...item, [related]: relatedItem };
    }
    const relatedData = db.data[related];
    if (!relatedData) {
        return item;
    }
    const foreignKey = `${inflection.singularize(name)}Id`;
    const relatedItems = relatedData.filter((relatedItem) => relatedItem[foreignKey] === item['id']);
    return { ...item, [related]: relatedItems };
}
function nullifyForeignKey(db, name, id) {
    const foreignKey = `${inflection.singularize(name)}Id`;
    Object.entries(db.data).forEach(([key, items]) => {
        // Skip
        if (key === name)
            return;
        // Nullify
        if (Array.isArray(items)) {
            items.forEach((item) => {
                if (item[foreignKey] === id) {
                    item[foreignKey] = null;
                }
            });
        }
    });
}
function deleteDependents(db, name, dependents) {
    const foreignKey = `${inflection.singularize(name)}Id`;
    Object.entries(db.data).forEach(([key, items]) => {
        // Skip
        if (key === name || !dependents.includes(key))
            return;
        // Delete if foreign key is null
        if (Array.isArray(items)) {
            db.data[key] = items.filter((item) => item[foreignKey] !== null);
        }
    });
}
export class Service {
    #db;
    constructor(db) {
        this.#db = db;
    }
    #get(name) {
        return this.#db.data[name];
    }
    has(name) {
        return Object.prototype.hasOwnProperty.call(this.#db?.data, name);
    }
    findById(name, id, query) {
        const value = this.#get(name);
        if (Array.isArray(value)) {
            let item = value.find((item) => item['id'] === id);
            ensureArray(query._embed).forEach((related) => {
                if (item !== undefined)
                    item = embed(this.#db, name, item, related);
            });
            return item;
        }
        return;
    }
    find(name, opts) {
        const items = this.#get(name);
        if (!Array.isArray(items)) {
            return items;
        }
        let results = items;
        // Include
        ensureArray(opts.embed).forEach((related) => {
            results = results.map((item) => embed(this.#db, name, item, related));
        });
        results = results.filter((item) => matchesWhere(item, opts.where));
        if (opts.sort) {
            results = sortOn(results, opts.sort.split(','));
        }
        if (opts.page !== undefined) {
            return paginate(results, opts.page, opts.perPage ?? 10);
        }
        return results;
    }
    async create(name, data = {}) {
        const items = this.#get(name);
        if (items === undefined || !Array.isArray(items))
            return;
        const item = { ...data, id: randomId() };
        items.push(item);
        await this.#db.write();
        return item;
    }
    async #updateOrPatch(name, body = {}, isPatch) {
        const item = this.#get(name);
        if (item === undefined || Array.isArray(item))
            return;
        const nextItem = (this.#db.data[name] = isPatch ? { ...item, ...body } : body);
        await this.#db.write();
        return nextItem;
    }
    async #updateOrPatchById(name, id, body = {}, isPatch) {
        const items = this.#get(name);
        if (items === undefined || !Array.isArray(items))
            return;
        const item = items.find((item) => item['id'] === id);
        if (!item)
            return;
        const nextItem = isPatch ? { ...item, ...body, id } : { ...body, id };
        const index = items.indexOf(item);
        items.splice(index, 1, nextItem);
        await this.#db.write();
        return nextItem;
    }
    async update(name, body = {}) {
        return this.#updateOrPatch(name, body, false);
    }
    async patch(name, body = {}) {
        return this.#updateOrPatch(name, body, true);
    }
    async updateById(name, id, body = {}) {
        return this.#updateOrPatchById(name, id, body, false);
    }
    async patchById(name, id, body = {}) {
        return this.#updateOrPatchById(name, id, body, true);
    }
    async destroyById(name, id, dependent) {
        const items = this.#get(name);
        if (items === undefined || !Array.isArray(items))
            return;
        const item = items.find((item) => item['id'] === id);
        if (item === undefined)
            return;
        const index = items.indexOf(item);
        items.splice(index, 1);
        nullifyForeignKey(this.#db, name, id);
        const dependents = ensureArray(dependent);
        deleteDependents(this.#db, name, dependents);
        await this.#db.write();
        return item;
    }
}
