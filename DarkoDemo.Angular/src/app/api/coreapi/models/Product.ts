/* generated using openapi-typescript-codegen -- do not edit */
/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */
import type { ProductCategory } from './ProductCategory';
export type Product = {
    id?: string;
    name?: string;
    description?: string | null;
    price?: number;
    stockQuantity?: number;
    createdDate?: string;
    modifiedDate?: string | null;
    active?: boolean;
    productCategories?: Array<ProductCategory>;
    basketItems?: any;
    orderItems?: any;
};

