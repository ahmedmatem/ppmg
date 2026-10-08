import { WHERE_OPERATORS } from "./where-operators.js";
function isJSONObject(value) {
    return typeof value === 'object' && value !== null && !Array.isArray(value);
}
function getKnownOperators(value) {
    if (!isJSONObject(value))
        return [];
    const ops = [];
    for (const op of WHERE_OPERATORS) {
        if (op in value) {
            ops.push(op);
        }
    }
    return ops;
}
export function matchesWhere(obj, where) {
    for (const [key, value] of Object.entries(where)) {
        if (key === 'or') {
            if (!Array.isArray(value) || value.length === 0)
                return false;
            let matched = false;
            for (const subWhere of value) {
                if (isJSONObject(subWhere) && matchesWhere(obj, subWhere)) {
                    matched = true;
                    break;
                }
            }
            if (!matched)
                return false;
            continue;
        }
        const field = obj[key];
        if (isJSONObject(value)) {
            const knownOps = getKnownOperators(value);
            if (knownOps.length > 0) {
                if (field === undefined)
                    return false;
                const op = value;
                if (knownOps.includes('lt') && !(field < op.lt))
                    return false;
                if (knownOps.includes('lte') && !(field <= op.lte))
                    return false;
                if (knownOps.includes('gt') && !(field > op.gt))
                    return false;
                if (knownOps.includes('gte') && !(field >= op.gte))
                    return false;
                if (knownOps.includes('eq') && !(field === op.eq))
                    return false;
                if (knownOps.includes('ne') && !(field !== op.ne))
                    return false;
                if (knownOps.includes('in')) {
                    const inValues = Array.isArray(op.in) ? op.in : [op.in];
                    if (!inValues.some((v) => field === v))
                        return false;
                }
                if (knownOps.includes('contains')) {
                    if (typeof field !== 'string')
                        return false;
                    if (!field.toLowerCase().includes(String(op.contains).toLowerCase()))
                        return false;
                }
                if (knownOps.includes('startsWith')) {
                    if (typeof field !== 'string')
                        return false;
                    if (!field.toLowerCase().startsWith(String(op.startsWith).toLowerCase()))
                        return false;
                }
                if (knownOps.includes('endsWith')) {
                    if (typeof field !== 'string')
                        return false;
                    if (!field.toLowerCase().endsWith(String(op.endsWith).toLowerCase()))
                        return false;
                }
                continue;
            }
            if (isJSONObject(field)) {
                if (!matchesWhere(field, value))
                    return false;
            }
            continue;
        }
        if (field === undefined)
            return false;
        return false;
    }
    return true;
}
