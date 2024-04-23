import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root',
})
export class TodoService {
  private baseUrl = 'http://localhost:your_port/api/todos'; // Assicurati di sostituire 'your_port' con la porta del tuo server

  constructor(private http: HttpClient) {}

  getTodos(showCompleted: boolean): Observable<any[]> {
    return this.http
      .get<any[]>(`${this.baseUrl}?showCompleted=${showCompleted}`)
      .pipe(catchError(this.handleError));
  }

  addTodo(todoData: any): Observable<any> {
    return this.http
      .post<any>(this.baseUrl, todoData)
      .pipe(catchError(this.handleError));
  }

  updateTodoStatus(todoId: string, check: boolean): Observable<any> {
    return this.http
      .put<any>(`${this.baseUrl}/${todoId}?check=${check}`, {})
      .pipe(catchError(this.handleError));
  }

  private handleError(error: HttpErrorResponse): Observable<any> {
    if (error.error instanceof ErrorEvent) {
      // Errore lato client
      console.error('An error occurred:', error.error.message);
    } else {
      // Errore lato server
      console.error(
        `Backend returned code ${error.status}, ` + `body was: ${error.error}`
      );
    }
    // Restituisce un observable con un messaggio di errore
    return throwError('Something bad happened; please try again later.');
  }
}
