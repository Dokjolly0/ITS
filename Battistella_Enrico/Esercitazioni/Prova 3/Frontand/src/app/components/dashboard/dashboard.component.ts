import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { AuthService } from '../../services/auth.service';
import { TodoService } from '../../services/todo.service';
import { Todo } from '../../entity/todo.entity';
import { Router } from '@angular/router';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css'],
})
export class DashboardComponent implements OnInit {
  todos: Todo[] = [];
  fullName: string = '';
  completed: boolean = false;

  isView: boolean = false;
  isAdd: boolean = false;
  isCheck: boolean = false;
  isAssigned: boolean = false;
  isDelate: boolean = false;

  @ViewChild('completedCheckbox')
  completedCheckbox!: ElementRef<HTMLInputElement>;

  constructor(
    private authService: AuthService,
    private todoService: TodoService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.fullName = this.todoService.getUserFullName();
    console.log("Nome completo dell'utente:", this.fullName);
  }

  onChangeCompleted(): void {
    // Aggiorna i todo quando lo stato del checkbox cambia
    this.onClickViewTodo();
  }

  // Metodi per gestire i clic sui pulsanti
  onClickViewTodo(): void {
    this.isView = true;
    this.isAdd = false;
    this.isCheck = false;
    this.isAssigned = false;
    this.isDelate = false;

    // Assume che il token sia già disponibile come una stringa
    const token = localStorage.getItem('token');

    // Chiama il metodo getTodo del servizio TodoService passando il token
    this.todoService.getTodo(token!, this.completed).subscribe(
      (response: Todo[]) => {
        // Assegna i todo recuperati all'array todos
        this.todos = response;
        //console.log('Todo recuperati:', this.todos);
      },
      (error: any) => {
        console.error('Errore durante il recupero dei todo:', error);
      }
    );
  }

  data: any = {};
  onClickAddTodo(): void {
    this.isView = false;
    this.isAdd = true;
    this.isCheck = false;
    this.isAssigned = false;
    this.isDelate = false;

    this.todos = [];
    this.data = this.todoService.getSharedData();

    console.log(this.data);

    //Il problema è che gli passi i dati quando clicchi sul pulsante ancora prima che l'utente possa inserire i dati
  }

  onClickFlagCompleted(): void {
    this.isView = false;
    this.isAdd = false;
    this.isCheck = true;
    this.isAssigned = false;
    this.isDelate = false;
    this.todos = [];
  }

  onClickNewAssign(): void {
    this.isView = false;
    this.isAdd = false;
    this.isCheck = false;
    this.isAssigned = true;
    this.isDelate = false;
    this.todos = [];
  }

  onClickDelate() {
    this.isView = false;
    this.isAdd = false;
    this.isCheck = false;
    this.isAssigned = false;
    this.isDelate = true;
    this.todos = [];
  }

  logout(): void {
    this.authService.logout();
    this.router.navigate(['/']);
  }
}
console.log('Script caricato');

//Registrarti a render e fai l'accesso con gitHub e scegli la cartella del beckand
// comando ng deploy --base-href=/angular-todo/
// Configura nelle impostazioni della repo setting deployment github pages
