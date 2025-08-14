/* generated using openapi-typescript-codegen -- do not edit */
/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import type { Observable } from 'rxjs';
import type { ProductWrite } from '../models/ProductWrite';
import { OpenAPI } from '../core/OpenAPI';
import { request as __request } from '../core/request';
@Injectable({
    providedIn: 'root',
})
export class ProductsService {
    constructor(public readonly http: HttpClient) {}
    /**
     * @returns any OK
     * @throws ApiError
     */
    public getProducts(): Observable<any> {
        return __request(OpenAPI, this.http, {
            method: 'GET',
            url: '/Products',
        });
    }
    /**
     * @param requestBody
     * @returns any OK
     * @throws ApiError
     */
    public postProducts(
        requestBody: ProductWrite,
    ): Observable<any> {
        return __request(OpenAPI, this.http, {
            method: 'POST',
            url: '/Products',
            body: requestBody,
            mediaType: 'application/json',
        });
    }
    /**
     * @param id
     * @returns any OK
     * @throws ApiError
     */
    public deleteProducts(
        id: string,
    ): Observable<any> {
        return __request(OpenAPI, this.http, {
            method: 'DELETE',
            url: '/Products/{id}',
            path: {
                'id': id,
            },
        });
    }
}
