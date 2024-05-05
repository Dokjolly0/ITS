import { Component, Input } from '@angular/core';
import { Todo } from '../../entity/todo.entity';

@Component({
  selector: 'app-todo-card',
  templateUrl: './todo.card.component.html',
  styleUrls: ['./todo.card.component.css'],
})
export class TodoCardComponent {
  @Input() todos: Todo[] = []; // Dichiarazione della proprietà 'todos' come input con inizializzazione
  description = false; // Dichiarazione della proprietà 'description' con inizializzazione
}
