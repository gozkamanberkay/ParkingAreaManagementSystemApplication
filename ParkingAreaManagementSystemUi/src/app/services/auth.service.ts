import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { ApiService } from './api.service';
import { Observable, of } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { LoginRequest } from './../models/requests/login-request';
import { RegisterRequest } from './../models/requests/register-request';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  constructor(private router: Router, private apiService: ApiService) {}

  login(request: LoginRequest): Observable<boolean> {
    return this.apiService.login(request).pipe(
      map((response) => {
        const token = response.data?.accessToken;
        const refreshToken = response.data?.refreshToken;

        if (token && refreshToken) {
          localStorage.setItem('accessToken', token);
          localStorage.setItem('refreshToken', refreshToken);

          return true;
        }

        return false;
      }),
      catchError((error) => {
        console.error('Login failed', error);

        return of(false);
      })
    );
  }

  register(request: RegisterRequest): Observable<boolean> {
    return this.apiService.register(request).pipe(
      map((response) => {
        const token = response.data?.accessToken;
        const refreshToken = response.data?.refreshToken;

        if (token && refreshToken) {
          localStorage.setItem('accessToken', token);
          localStorage.setItem('refreshToken', refreshToken);

          return true;
        }

        return false;
      }),
      catchError((error) => {
        console.error('Registration failed', error);
        return of(false);
      })
    );
  }

  logout(): void {
    localStorage.removeItem('accessToken');
    localStorage.removeItem('refreshToken');

    this.router.navigate(['/login']);
  }

  isAuthenticated(): boolean {
    return !!localStorage.getItem('accessToken');
  }

  refreshToken(): Observable<boolean> {
    const refreshToken = localStorage.getItem('refreshToken');

    if (!refreshToken) {
      this.logout();

      return of(false);
    }

    return this.apiService.refreshToken(refreshToken).pipe(
      map((response) => {
        const newAccessToken = response.data?.accessToken;

        if (newAccessToken) {
          localStorage.setItem('accessToken', newAccessToken);

          return true;
        }

        return false;
      }),
      catchError((error) => {
        console.error('Token refresh failed', error);

        this.logout();

        return of(false);
      })
    );
  }
}
