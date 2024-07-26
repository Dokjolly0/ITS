import { Component } from '@angular/core';
import { Todo } from '../../entity/todo.entity';
import { TodoService } from '../../services/todo.service';

@Component({
  selector: 'app-delate',
  templateUrl: './delate.component.html',
  styleUrl: './delate.component.css',
})
export class DelateComponent {
  title: string = '';
  completed: boolean = true;
  isView: boolean = false;
  isAdd: boolean = false;
  isCheck: boolean = false;
  isUncheck: boolean = false;
  isDelate: boolean = false;
  todos: Todo[] = [];
  token: string = localStorage.getItem('token')!;

  constructor(private todoService: TodoService) {}

  searchAll(): void {
    this.isView = false;
    this.isAdd = false;
    this.isCheck = false;
    this.isUncheck = false;
    this.isDelate = true;

    // Chiama il metodo getTodo del servizio TodoService passando il token
    this.todoService.getTodo(this.token!, this.completed).subscribe(
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

  onDelate() {
    const id = (document.getElementById('id') as HTMLInputElement).value;

    this.todoService.delate(id, this.token).subscribe(
      (response: any) => {
        console.log('Todo eliminato:', response);
        this.searchAll();
      },
      (error: any) => {
        console.error("Errore durante l'eliminazione del todo:", error);
      }
    );
  }
}
