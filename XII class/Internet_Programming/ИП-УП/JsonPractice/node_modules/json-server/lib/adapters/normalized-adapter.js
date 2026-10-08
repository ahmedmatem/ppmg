import { randomId } from "../random-id.js";
export const DEFAULT_SCHEMA_PATH = './node_modules/json-server/schema.json';
export class NormalizedAdapter {
    #adapter;
    constructor(adapter) {
        this.#adapter = adapter;
    }
    async read() {
        const data = await this.#adapter.read();
        if (data === null) {
            return null;
        }
        delete data['$schema'];
        for (const value of Object.values(data)) {
            if (Array.isArray(value)) {
                for (const item of value) {
                    if (typeof item['id'] === 'number') {
                        item['id'] = item['id'].toString();
                    }
                    if (item['id'] === undefined) {
                        item['id'] = randomId();
                    }
                }
            }
        }
        return data;
    }
    async write(data) {
        await this.#adapter.write({ ...data, $schema: DEFAULT_SCHEMA_PATH });
    }
}
