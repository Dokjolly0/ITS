import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, switchMap, tap } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class TodoService {
  constructor(private http: HttpClient) {}

  getTodo(token: string, completed: boolean): Observable<any> {
    // Includi direttamente il token nell'intestazione della richiesta HTTP
    const headers = new HttpHeaders().set('Authorization', `Bearer ${token}`);

    // Costruisci l'URL per la richiesta HTTP in base al valore di completed
    let url = 'http://localhost:3000/api/todos';
    if (completed) {
      // Aggiungi il parametro completed all'URL quando è true
      url += '?completed=true';
    }

    // Esegui la richiesta GET utilizzando l'URL costruito
    return this.http.get(url, { headers });
  }

  getUserFullName(): string {
    // Ottieni il nome completo dell'utente
    const user = this.getUser();
    return user ? `${user.firstName} ${user.lastName}` : '';
  }

  private getUser() {
    // Implementa la logica per ottenere l'utente dal servizio appropriato
    // Ad esempio, puoi chiamare un endpoint API per recuperare le informazioni dell'utente
    // oppure recuperare l'utente da un'altra sorgente di dati, come il localStorage
    // In questo esempio, assumiamo che l'utente sia memorizzato nel localStorage
    const userJson = localStorage.getItem('user');
    return userJson ? JSON.parse(userJson) : null;
  }
}
