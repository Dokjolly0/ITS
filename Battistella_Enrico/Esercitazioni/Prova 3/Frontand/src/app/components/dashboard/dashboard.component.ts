import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../services/auth.service';
import { TodoService } from '../../services/todo.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css'],
})
export class DashboardComponent implements OnInit {
  fullName: string = '';

  constructor(
    private authService: AuthService,
    private todoService: TodoService,
    private router: Router
  ) {}

  ngOnInit(): void {
    // Recupera il nome completo dell'utente dopo il login
    this.fullName = this.todoService.getUserFullName();
  }

  onClickViewTodo(): void {
    alert('Hai cliccato sul pulsante "Visualizza Todo"');
  }

  onClickAddTodo(): void {
    alert('Hai cliccato sul pulsante "Aggiungere un Todo"');
  }

  onClickFlagCompleted(): void {
    alert('Hai cliccato sul pulsante "Flagga Completato"');
  }

  onClickFlagIncomplete(): void {
    alert('Hai cliccato sul pulsante "Flagga Non Completato"');
  }

  logout(): void {
    this.authService.logout();
    this.router.navigate(['/']); // Naviga verso la home page dopo il logout
  }
}
console.log('Script caricato');

// onClickViewTodo(): void {
//   alert('Hai cliccato sul pulsante "Visualizza Todo"');
// }

// onClickAddTodo(): void {
//   alert('Hai cliccato sul pulsante "Aggiungere un Todo"');
// }

// onClickFlagCompleted(): void {
//   alert('Hai cliccato sul pulsante "Flagga Completato"');
// }

// onClickFlagIncomplete(): void {
//   alert('Hai cliccato sul pulsante "Flagga Non Completato"');
// }
