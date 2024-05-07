import { Component } from '@angular/core';
import { TodoService } from '../../services/todo.service';
import { Todo } from '../../entity/todo.entity';
import { DashboardComponent } from '../dashboard/dashboard.component';

@Component({
  selector: 'app-change-completed',
  templateUrl: './change-completed.component.html',
  styleUrl: './change-completed.component.css',
})
export class ChangeCompletedComponent {
  constructor(
    private todoService: TodoService,
    private dashboard: DashboardComponent
  ) {}
  isView: Boolean = false;
  isAdd: Boolean = false;
  isCheck: Boolean = false;
  isUncheck: Boolean = false;
  completed: boolean = true;

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
        console.error(
          'Errore durante il recupero della lista dei todo:',
          error
        );
      }
    );
  }
  onComplete(completed: boolean) {
    this.id = (document.getElementById('submit') as HTMLInputElement).value;
    //console.log('ID:', this.id);
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
}
