/* generated using openapi-typescript-codegen -- do not edit */
/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */
import type { Basket } from './Basket';
import type { Product } from './Product';
export type BasketItem = {
    id?: string;
    quantity?: number;
    unitPrice?: number;
    createdDate?: string;
    modifiedDate?: string | null;
    active?: boolean;
    basketId?: string;
    basket?: Basket;
    productId?: string;
    product?: Product;
};

