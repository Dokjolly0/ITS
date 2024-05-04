import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private token: string | null = null;

  constructor(private http: HttpClient) {}

  login(username: string, password: string): Observable<any> {
    return this.http
      .post<any>('http://localhost:3000/api/auth/login', { username, password })
      .pipe(
        tap((response: { token: any }) => {
          localStorage.setItem('token', response.token);
          console.log('Token:', response.token);
        })
      );
  }
  isLoggedIn(): boolean {
    // Verifica se il token è presente nel localStorage o in un altro luogo
    return !!localStorage.getItem('token');
  }
  setToken(token: string): void {
    this.token = token;
  }

  getToken(): string | null {
    return this.token;
  }

  isAuthenticated(): boolean {
    return !!this.token;
  }

  logout(): void {
    localStorage.removeItem('token');
    this.token = null;
  }
}
