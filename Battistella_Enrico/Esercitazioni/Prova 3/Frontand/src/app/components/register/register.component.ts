import { Component, OnInit } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { AuthService } from '../../services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./css/style.css'],
})
export class RegisterComponent implements OnInit {
  constructor(
    private title: Title,
    private authService: AuthService,
    private router: Router
  ) {}
  firstName: string = '';
  lastName: string = '';
  username: string = '';
  password: string = '';
  confirmPassword: string = '';
  picture: string = '';

  ngOnInit(): void {
    this.title.setTitle('ToDo App - Registrazione');
  }
  onRegister() {
    const nomeInput = document.getElementById('nome') as HTMLInputElement;
    const cognomeInput = document.getElementById('cognome') as HTMLInputElement;
    const usernameInput = document.getElementById('email') as HTMLInputElement;
    const passInput = document.getElementById('pass') as HTMLInputElement;
    const checkPassInput = document.getElementById(
      'check_pass'
    ) as HTMLInputElement;
    const pictureInput = document.getElementById('picture') as HTMLInputElement;

    console.log('Nome: ' + nomeInput.value);
    console.log('Cognome: ' + cognomeInput.value);
    console.log('Username: ' + usernameInput.value);
    console.log('Password: ' + passInput.value);
    console.log('Conferma password: ' + checkPassInput.value);
    console.log('Immagine: ' + pictureInput.value);

    if (
      nomeInput.value === '' ||
      cognomeInput.value === '' ||
      usernameInput.value === '' ||
      passInput.value === '' ||
      checkPassInput.value === '' ||
      pictureInput.value === ''
    ) {
      alert('Compilare tutti i campi');
      return;
    } else {
      if (passInput.value !== checkPassInput.value) {
        alert('Le password non corrispondono');
        return;
      } else {
        this.authService
          .register(
            nomeInput.value,
            cognomeInput.value,
            usernameInput.value,
            passInput.value,
            pictureInput.value
          )
          .subscribe(
            (response) => {
              console.log(response);
              alert('Registrazione avvenuta con successo');
              this.router.navigate(['/login']);
            },
            (error: any) => {
              console.log(error);
              alert('Errore durante la registrazione' + error.message);
            }
          );
      }
    }
  }
}
