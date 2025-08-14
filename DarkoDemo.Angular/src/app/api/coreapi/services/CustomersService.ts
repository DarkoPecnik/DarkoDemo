/* generated using openapi-typescript-codegen -- do not edit */
/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import type { Observable } from 'rxjs';
import type { Customer } from '../models/Customer';
import type { CustomerRead } from '../models/CustomerRead';
import { OpenAPI } from '../core/OpenAPI';
import { request as __request } from '../core/request';
@Injectable({
    providedIn: 'root',
})
export class CustomersService {
    constructor(public readonly http: HttpClient) {}
    /**
     * @returns CustomerRead OK
     * @throws ApiError
     */
    public getCustomers(): Observable<Array<CustomerRead>> {
        return __request(OpenAPI, this.http, {
            method: 'GET',
            url: '/Customers',
        });
    }
    /**
     * @param id
     * @returns Customer OK
     * @throws ApiError
     */
    public getCustomers1(
        id: string,
    ): Observable<Customer> {
        return __request(OpenAPI, this.http, {
            method: 'GET',
            url: '/Customers/{id}',
            path: {
                'id': id,
            },
        });
    }
}
