/* generated using openapi-typescript-codegen -- do not edit */
/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */
import type { Basket } from './Basket';
import type { Order } from './Order';
export type Customer = {
    id?: string;
    name?: string;
    email?: string;
    firstName?: string | null;
    lastName?: string | null;
    secret?: string | null;
    createdDate?: string;
    modifiedDate?: string | null;
    active?: boolean;
    baskets?: Array<Basket>;
    orders?: Array<Order>;
};

