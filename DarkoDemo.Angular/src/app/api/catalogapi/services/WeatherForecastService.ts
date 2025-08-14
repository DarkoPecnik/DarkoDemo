/* generated using openapi-typescript-codegen -- do not edit */
/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import type { Observable } from 'rxjs';
import type { WeatherForecast } from '../models/WeatherForecast';
import { OpenAPI } from '../core/OpenAPI';
import { request as __request } from '../core/request';
@Injectable({
    providedIn: 'root',
})
export class WeatherForecastService {
    constructor(public readonly http: HttpClient) {}
    /**
     * @returns WeatherForecast OK
     * @throws ApiError
     */
    public getWeatherForecast(): Observable<Array<WeatherForecast>> {
        return __request(OpenAPI, this.http, {
            method: 'GET',
            url: '/WeatherForecast',
        });
    }
}
