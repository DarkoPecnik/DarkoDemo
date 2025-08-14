/* generated using openapi-typescript-codegen -- do not edit */
/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import type { Observable } from 'rxjs';
import { OpenAPI } from '../core/OpenAPI';
import { request as __request } from '../core/request';
@Injectable({
    providedIn: 'root',
})
export class BasketService {
    constructor(public readonly http: HttpClient) {}
    /**
     * @param customerId
     * @returns any OK
     * @throws ApiError
     */
    public getBasket(
        customerId: string,
    ): Observable<any> {
        return __request(OpenAPI, this.http, {
            method: 'GET',
            url: '/Basket/{customerId}',
            path: {
                'customerId': customerId,
            },
        });
    }
    /**
     * @param productId
     * @param customerId
     * @returns any OK
     * @throws ApiError
     */
    public postBasket(
        productId: string,
        customerId?: string,
    ): Observable<any> {
        return __request(OpenAPI, this.http, {
            method: 'POST',
            url: '/Basket/{productId}',
            path: {
                'productId': productId,
            },
            query: {
                'customerId': customerId,
            },
        });
    }
}
