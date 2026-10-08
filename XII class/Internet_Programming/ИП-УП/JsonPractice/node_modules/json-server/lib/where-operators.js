export const WHERE_OPERATORS = [
    'lt',
    'lte',
    'gt',
    'gte',
    'eq',
    'ne',
    'in',
    'contains',
    'startsWith',
    'endsWith',
];
export function isWhereOperator(value) {
    return WHERE_OPERATORS.includes(value);
}
