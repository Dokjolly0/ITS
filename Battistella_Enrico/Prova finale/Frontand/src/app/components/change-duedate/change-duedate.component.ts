import { Component } from '@angular/core';
import { TodoService } from '../../services/todo.service';
import { DashboardComponent } from '../dashboard/dashboard.component';
import { Todo } from '../../entity/todo.entity';

@Component({
  selector: 'app-change-duedate',
  templateUrl: './change-duedate.component.html',
  styleUrl: './change-duedate.component.css',
})
export class ChangeDuedateComponent {
  constructor(private todoService: TodoService, private dashboard: DashboardComponent) {}
  isView: Boolean = false;
  isAdd: Boolean = false;
  isCheck: Boolean = false;
  isUncheck: Boolean = false;
  completed: boolean = true;
  statusTodo: boolean = false;

  todos: Todo[] = [];
  token = localStorage.getItem('token');
  title: string = '';
  id: string = '';

  onSubmitSearch() {
    this.title = (document.getElementById('title') as HTMLInputElement).value;
    this.todoService.getTodoByTitle(this.token!, this.title).subscribe(
      (response: any) => {
        if (!response) {
          console.log('La risposta non contiene la lista dei todo:', response);
          return;
        } else if (!response.todos) {
          this.todos = response;
          console.log('La risposta contiene:', response);
          return;
        }
        this.todos = response.todos;
        console.log('Lista dei todo:', this.todos);
      },
      (error: any) => {
        console.error('Errore durante il recupero della lista dei todo:', error);
      }
    );
  }

  searchAll(): void {
    this.isView = false;
    this.isAdd = false;
    this.isCheck = true;
    this.isUncheck = false;

    // Assume che il token sia già disponibile come una stringa
    const token = localStorage.getItem('token');

    // Chiama il metodo getTodo del servizio TodoService passando il token
    this.todoService.getTodo(token!, this.completed).subscribe(
      (response: Todo[]) => {
        // Assegna i todo recuperati all'array todos
        this.todos = response;
        console.log('Todo recuperati:', this.todos);
      },
      (error: any) => {
        console.error('Errore durante il recupero dei todo:', error);
      }
    );
  }

  onDate() {
    const submitElement = document.getElementById('submit') as HTMLInputElement;
    const newDate: string = submitElement.value;

    const idElement = document.getElementById('id') as HTMLInputElement;
    const id: string = idElement.value;

    if (!id) {
      alert('Inserisci un ID valido');
      return;
    }

    this.todoService.changeDueDate(id, newDate, this.token!).subscribe(
      (response: any) => {
        //console.log('Data aggiornata:', response);
        this.todos = [];
        this.todos.push(response);
        console.log('Todo aggiornato:', this.todos);
      },
      (error: any) => {
        console.error("Errore durante l'aggiornamento della data:", error);
      }
    );
    console.log('Nuova data:', newDate, 'ID:', id);
  }
}
