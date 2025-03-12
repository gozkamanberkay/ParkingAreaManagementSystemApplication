import { LoginRequest } from './../models/requests/login-request';
import { CheckOutRequest } from './../models/requests/check-out-request';
import { CheckInResponse } from './../models/responses/check-in-response';
import { BaseDataResponse } from './../models/responses/base-data-response';
import { GetAllParkingZonesResponse } from './../models/responses/get-all-parking-zones-response';
import { environment } from './../../environments/environment.dockerCompose';
import { HttpClient, HttpParams } from '@angular/common/http';
import { TokenResponse } from './../models/responses/token-response';
import { CheckOutResponse } from './../models/responses/check-out-response';
import { Injectable } from '@angular/core';
import { Observable, map } from 'rxjs';
import { CheckInRequest } from '../models/requests/check-in-request';
import { RegisterRequest } from '../models/requests/register-request';

@Injectable({
  providedIn: 'root',
})
export class ApiService {
  private endpoint = environment.api_url;

  constructor(private readonly httpClient: HttpClient) {}

  register(
    request: RegisterRequest
  ): Observable<BaseDataResponse<TokenResponse>> {
    return this.httpClient
      .post<BaseDataResponse<TokenResponse>>(
        this.endpoint + '/Auth/Register',
        request
      )
      .pipe(
        map((result) => {
          return result;
        })
      );
  }

  login(request: LoginRequest): Observable<BaseDataResponse<TokenResponse>> {
    return this.httpClient
      .post<BaseDataResponse<TokenResponse>>(
        this.endpoint + '/Auth/Login',
        request
      )
      .pipe(
        map((result) => {
          return result;
        })
      );
  }

  refreshToken(token: string): Observable<BaseDataResponse<TokenResponse>> {
    return this.httpClient
      .get<BaseDataResponse<TokenResponse>>(
        this.endpoint + '/Auth/RefreshToken',
        { params: new HttpParams().append('refreshToken', token) }
      )
      .pipe(
        map((result) => {
          return result;
        })
      );
  }

  getAllParkingZones(): Observable<
    BaseDataResponse<Array<GetAllParkingZonesResponse>>
  > {
    return this.httpClient
      .get<BaseDataResponse<Array<GetAllParkingZonesResponse>>>(
        this.endpoint + '/Dashboard/GetAllParkingZones'
      )
      .pipe(
        map((response) => {
          return response;
        })
      );
  }

  checkIn(
    request: CheckInRequest
  ): Observable<BaseDataResponse<CheckInResponse>> {
    return this.httpClient
      .post<BaseDataResponse<CheckInResponse>>(
        this.endpoint + '/Dashboard/CheckIn',
        request
      )
      .pipe(
        map((result) => {
          return result;
        })
      );
  }

  checkOut(
    request: CheckOutRequest
  ): Observable<BaseDataResponse<CheckOutResponse>> {
    return this.httpClient
      .post<BaseDataResponse<CheckOutResponse>>(
        this.endpoint + '/Dashboard/CheckOut',
        request
      )
      .pipe(
        map((result) => {
          return result;
        })
      );
  }
}
