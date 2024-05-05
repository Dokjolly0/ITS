import { Component, OnInit } from '@angular/core';
import { TodoService } from '../../services/user.service';

@Component({
  selector: 'app-add-todo',
  templateUrl: './add-todo.component.html',
  styleUrl: './add-todo.component.css',
})
export class AddTodoComponent implements OnInit {
  availableUsers: string[] = [];

  constructor(private todoService: TodoService) {} // Inietta il servizio TodoService nel costruttore

  ngOnInit(): void {
    this.getUserList(); // Chiama il metodo per ottenere la lista degli utenti disponibili
  }

  getUserList(): void {
    const token = localStorage.getItem('token');
    if (!token) {
      console.error('Nessun token disponibile.');
      return; // Esci dalla funzione se il token non è presente
    }

    this.todoService.getUserList(token).subscribe(
      (response: any) => {
        if (!response || !response.users) {
          console.log(
            'La risposta non contiene la lista degli utenti:',
            response
          );
          this.availableUsers = response; // Assegna la risposta all'array degli utenti disponibili
          // Estrai solo la proprietà fullName da ciascun oggetto
          // Estrai la proprietà fullName da ciascun oggetto e crea un array con i nomi completi
          this.availableUsers = response.map((user: any) => user.fullName);
          return; // Esci dalla funzione se la risposta non contiene la lista degli utenti
        }
        this.availableUsers = response.users;
        // Estrai la proprietà fullName da ciascun oggetto e crea un array con i nomi completi
        this.availableUsers = response.map((user: any) => user.fullName);
        console.log('Lista degli utenti:', this.availableUsers);
      },
      (error: any) => {
        console.error(
          'Errore durante il recupero della lista degli utenti:',
          error
        );
      }
    );
  }
}
