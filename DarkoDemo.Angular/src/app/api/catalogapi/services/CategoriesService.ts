/* generated using openapi-typescript-codegen -- do not edit */
/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import type { Observable } from 'rxjs';
import type { CategoryWrite } from '../models/CategoryWrite';
import { OpenAPI } from '../core/OpenAPI';
import { request as __request } from '../core/request';
@Injectable({
    providedIn: 'root',
})
export class CategoriesService {
    constructor(public readonly http: HttpClient) {}
    /**
     * @returns any OK
     * @throws ApiError
     */
    public getCategories(): Observable<any> {
        return __request(OpenAPI, this.http, {
            method: 'GET',
            url: '/Categories',
        });
    }
    /**
     * @param requestBody
     * @returns any OK
     * @throws ApiError
     */
    public postCategories(
        requestBody: CategoryWrite,
    ): Observable<any> {
        return __request(OpenAPI, this.http, {
            method: 'POST',
            url: '/Categories',
            body: requestBody,
            mediaType: 'application/json',
        });
    }
    /**
     * @param id
     * @returns any OK
     * @throws ApiError
     */
    public deleteCategories(
        id: string,
    ): Observable<any> {
        return __request(OpenAPI, this.http, {
            method: 'DELETE',
            url: '/Categories/{id}',
            path: {
                'id': id,
            },
        });
    }
}
