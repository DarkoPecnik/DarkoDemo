/* generated using openapi-typescript-codegen -- do not edit */
/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */
import type { Customer } from './Customer';
export type Basket = {
    id?: string;
    name?: string | null;
    createdDate?: string;
    modifiedDate?: string | null;
    active?: boolean;
    customerId?: string;
    customer?: Customer;
    items?: Array<any>;
};

