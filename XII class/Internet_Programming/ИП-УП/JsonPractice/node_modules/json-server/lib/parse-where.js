import { setProperty } from 'dot-prop';
import { isWhereOperator } from "./where-operators.js";
function splitKey(key) {
    const colonIdx = key.lastIndexOf(':');
    if (colonIdx !== -1) {
        const path = key.slice(0, colonIdx);
        const op = key.slice(colonIdx + 1);
        if (!op) {
            return { path: key, op: 'eq' };
        }
        return isWhereOperator(op) ? { path, op } : { path, op: null };
    }
    // Compatibility with v0.17 operator style (e.g. _lt, _gt)
    const underscoreMatch = key.match(/^(.*)_([a-z]+)$/);
    if (underscoreMatch) {
        const path = underscoreMatch[1];
        const op = underscoreMatch[2];
        if (path && isWhereOperator(op)) {
            return { path, op };
        }
    }
    return { path: key, op: 'eq' };
}
function setPathOp(root, path, op, value) {
    const fullPath = `${path}.${op}`;
    if (op === 'in') {
        setProperty(root, fullPath, value.split(',').map((part) => coerceValue(part.trim())));
        return;
    }
    setProperty(root, fullPath, coerceValue(value));
}
function coerceValue(value) {
    if (value === 'true')
        return true;
    if (value === 'false')
        return false;
    if (value === 'null')
        return null;
    if (value.trim() === '')
        return value;
    const num = Number(value);
    if (Number.isFinite(num))
        return num;
    return value;
}
export function parseWhere(query) {
    const out = {};
    const params = new URLSearchParams(query);
    for (const [rawKey, rawValue] of params.entries()) {
        const { path, op } = splitKey(rawKey);
        if (op === null)
            continue;
        setPathOp(out, path, op, rawValue);
    }
    return out;
}
