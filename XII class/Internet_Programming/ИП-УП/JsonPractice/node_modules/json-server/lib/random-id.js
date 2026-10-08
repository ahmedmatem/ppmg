import { randomBytes } from 'node:crypto';
export function randomId() {
    return randomBytes(8).toString('base64url');
}
