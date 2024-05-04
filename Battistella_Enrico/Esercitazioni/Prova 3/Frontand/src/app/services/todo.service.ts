import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class TodoService {
  constructor(private http: HttpClient) {}

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
