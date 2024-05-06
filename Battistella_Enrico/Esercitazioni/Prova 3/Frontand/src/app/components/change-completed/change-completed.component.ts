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

  onSubmitSearch() {
    const title = (document.getElementById('title') as HTMLInputElement).value;
    console.log('Titolo:', title);
  }
  onSubmit() {}
  id = (document.getElementById('id') as HTMLInputElement).value;
}
