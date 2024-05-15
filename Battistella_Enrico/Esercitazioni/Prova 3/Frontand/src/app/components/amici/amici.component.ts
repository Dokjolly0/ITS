import { Component, OnInit } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { AuthService } from '../../services/auth.service';
import { Router } from '@angular/router';
import { TodoService } from '../../services/todo.service';
import { User } from '../../entity/user.entity';
import { UserService } from '../../services/user.service';

@Component({
  selector: 'app-amici',
  templateUrl: './amici.component.html',
  styleUrls: ['./amici.component.css'],
})
export class AmiciComponent implements OnInit {
  constructor(
    private title: Title,
    private authService: AuthService,
    private router: Router,
    private todoService: TodoService,
    private userService: UserService
  ) {}
  fullName: string = '';
  picture: string = '';
  amici: string[] = [];
  token: string | null = localStorage.getItem('token');
  availableUsers: User[] = [];
  username: string = '';
  user: User[] = [];

  ngOnInit(): void {
    this.title.setTitle('T<oDo App - Amici');
    this.fullName = this.todoService.getUserFullName();
    this.picture = this.todoService.getUserPicture();
    console.log(this.user);
    //this.getUserList();
    alert('Pagina ancora in fase di sviluppo, le funzionalità non sono ancora implementate 😅');
  }

  timeoutId: any | null = null;
  onClickUser() {
    const dropdown = document.querySelector('.dropdown');

    if (dropdown) {
      dropdown.classList.toggle('show');

      // Se il dropdown è stato aperto, impostiamo un timeout per chiuderlo dopo 5 secondi
      if (dropdown.classList.contains('show')) {
        // Cancella il timeout precedente, se presente
        if (this.timeoutId) {
          clearTimeout(this.timeoutId);
        }

        this.timeoutId = setTimeout(() => {
          dropdown.classList.remove('show');
          this.timeoutId = null; // Resetta il timeoutId dopo aver chiuso il dropdown
        }, 5000); // 5000 millisecondi = 5 secondi
      }
    }
  }

  getUserList(): void {
    if (!this.token) {
      console.error('Nessun token disponibile.');
      return; // Esci dalla funzione se il token non è presente
    }

    this.userService.getUserList(this.token).subscribe(
      (response: any) => {
        if (!response || !response.users) {
          console.log('La risposta non contiene la lista degli utenti:', response);
          // Estrai la proprietà fullName da ciascun oggetto e crea un array con i nomi completi
          this.availableUsers = response.map((user: any) => user.fullName);
          //esci dalla funzione se la risposta non contiene la lista degli utenti
          return;
        }
        this.availableUsers = response.users;
        // Estrai la proprietà fullName da ciascun oggetto e crea un array con i nomi completi
        this.availableUsers = response.map((user: any) => user.fullName);
        console.log('Lista degli utenti:', this.availableUsers);
      },
      (error: any) => {
        console.error('Errore durante il recupero della lista degli utenti:', error);
      }
    );
  }

  searchUser() {
    console.log('Cerca utente');
    this.username = (document.getElementById('userUsername') as HTMLInputElement).value;
    this.todoService.findUserByFullName(this.token!, this.username).subscribe(
      (response: any) => {
        if (!response) {
          console.log('La risposta non contiene la lista dei todo:', response);
          return;
        } else if (!response.user) {
          this.user = response;
          console.log('La risposta contiene:', response);
          return;
        }
        this.user = response.user;
        console.log('Lista degli utenti:', this.user);
      },
      (error: any) => {
        console.error('Errore durante il recupero della lista degli utenti:', error);
      }
    );
  }

  logout(): void {
    this.authService.logout();
    this.router.navigate(['/']);
  }
}
// const dropdown = document.querySelector('.dropdown');
// const userIcon = document.getElementById('userIcon');

// if (userIcon) {
//   userIcon.addEventListener('click', function () {
//     if (dropdown) dropdown.classList.toggle('show');
//     if (dropdown?.classList.contains('show')) {
//       userIcon.style.right = '-100px';
//       // userIcon.classList.add("sliderUser");
//       // userIcon.classList.remove("sliderUserReverse");
//     } else {
//       // userIcon.classList.add("sliderUserReverse");
//       // userIcon.classList.remove("sliderUser");
//       userIcon.style.right = '60px';
//     }
//   });
// }
