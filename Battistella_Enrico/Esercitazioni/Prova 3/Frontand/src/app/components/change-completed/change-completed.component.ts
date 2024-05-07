import { Component } from '@angular/core';
import { TodoService } from '../../services/todo.service';
import { Todo } from '../../entity/todo.entity';

@Component({
  selector: 'app-change-completed',
  templateUrl: './change-completed.component.html',
  styleUrl: './change-completed.component.css',
})
export class ChangeCompletedComponent {
  constructor(private todoService: TodoService) {}
  todos: Todo[] = [];
  token = localStorage.getItem('token');
  title: string = '';
  id: string = '';

  onSubmitSearch() {
    this.title = (document.getElementById('title') as HTMLInputElement).value;
    console.log('Titolo:', this.title);
    this.todoService.getTodoByTitle(this.token!, this.title).subscribe(
      (response: any) => {
        if (!response || !response.todos) {
          console.log('La risposta non contiene la lista dei todo:', response);
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
  onSubmit() {
    this.id = (document.getElementById('submit') as HTMLInputElement).value;
    //console.log('ID:', this.id);
  }
}
