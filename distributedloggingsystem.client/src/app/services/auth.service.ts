import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';

@Injectable({ providedIn: 'root' })
export class AuthService {
  private baseURL = 'https://localhost:7104/auth';

  private token: string | undefined;

  constructor(private http: HttpClient) {}

  getToken(): Observable<any> {
    return this.http.post<any>(`${this.baseURL}/token`, null).pipe(
      tap((response) => {
        this.token = response.token;
        localStorage.setItem('authToken', this.token as string);
      })
    );
  }

  getAuthToken(): string | null {
    return this.token || localStorage.getItem('authToken');
  }
}
