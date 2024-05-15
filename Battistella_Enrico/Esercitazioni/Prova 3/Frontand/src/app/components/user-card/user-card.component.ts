import { Component } from '@angular/core';
import { TodoService } from '../../services/todo.service';
import { UserService } from '../../services/user.service';
import { AuthService } from '../../services/auth.service';
import { Title } from '@angular/platform-browser';
import { Router } from '@angular/router';
import { User } from '../../entity/user.entity';

@Component({
  selector: 'app-user-card',
  templateUrl: './user-card.component.html',
  styleUrl: './user-card.component.css',
})
export class UserCardComponent {
  constructor(
    private title: Title,
    private authService: AuthService,
    private router: Router,
    private todoService: TodoService,
    private userService: UserService
  ) {}
  fullName: string = '';
  amici: string[] = [];
  token: string | null = localStorage.getItem('token');
  availableUsers: User[] = [];

  ngOnInit(): void {
    this.title.setTitle('T<oDo App - Amici');
    this.getUserList();
    console.log(this.availableUsers);
  }

  getUserList(): void {
    if (!this.token) {
      console.error('Nessun token disponibile.');
      return; // Esci dalla funzione se il token non è presente
    }

    this.userService.getUserList(this.token).subscribe(
      (response: any) => {
        if (!response || !response.users) {
          console.log(
            'La risposta non contiene la lista degli utenti:',
            (this.availableUsers = response)
          );
          //esci dalla funzione se la risposta non contiene la lista degli utenti
          return;
        }
        this.availableUsers = response.users;
        // Estrai la proprietà fullName da ciascun oggetto e crea un array con i nomi completi
        console.log('Lista degli utenti:', this.availableUsers);
        return this.availableUsers;
      },
      (error: any) => {
        console.error(
          'Errore durante il recupero della lista degli utenti:',
          error
        );
      }
    );
  }

  copyUserId(userId: string): void {
    navigator.clipboard.writeText(userId).then(
      () => {
        alert('ID utente copiato negli appunti! ' + userId);
      },
      (error) => {
        console.error("Errore durante la copia dell'ID utente:", error);
      }
    );
  }
}
