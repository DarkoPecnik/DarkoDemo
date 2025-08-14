/* generated using openapi-typescript-codegen -- do not edit */
/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */
import type { Customer } from './Customer';
import type { OrderItem } from './OrderItem';
import type { OrderStatus } from './OrderStatus';
export type Order = {
    id?: string;
    orderDate?: string;
    totalAmount?: number;
    status?: OrderStatus;
    customerId?: string;
    customer?: Customer;
    items?: Array<OrderItem>;
};

