import { Component, OnInit } from '@angular/core';
import { TodoService } from './service/todo.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent implements OnInit {
  todos: any[] = [];
  activeTodos: any[] = []; // Dichiarazione di activeTodos

  constructor(private todoService: TodoService) {}

  ngOnInit() {
    this.loadTodos();
  }

  loadTodos() {
    this.todoService.getTodos(false).subscribe((todos) => {
      this.todos = todos;
      this.activeTodos = this.todos.filter((todo) => !todo.completed);
    });
  }

  onSubmit() {
    // Logica per gestire l'invio del form
  }
}
