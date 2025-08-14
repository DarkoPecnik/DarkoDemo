/* generated using openapi-typescript-codegen -- do not edit */
/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */
import type { Order } from './Order';
import type { Product } from './Product';
export type OrderItem = {
    id?: string;
    quantity?: number;
    unitPrice?: number;
    createdDate?: string;
    modifiedDate?: string | null;
    active?: boolean;
    orderId?: string;
    order?: Order;
    productId?: string;
    product?: Product;
};

