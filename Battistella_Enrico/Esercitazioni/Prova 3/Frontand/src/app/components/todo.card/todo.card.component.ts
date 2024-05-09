import { Component, Input, OnInit } from '@angular/core';
import { Todo } from '../../entity/todo.entity';

@Component({
  selector: 'app-todo-card',
  templateUrl: './todo.card.component.html',
  styleUrls: ['./todo.card.component.css'],
})
export class TodoCardComponent implements OnInit {
  @Input() todos: Todo[] = []; // Dichiarazione della proprietà 'todos' come input con inizializzazione

  ngOnInit(): void {
    console.log('Lista dei todo:', this.todos);
  }

  copyTodoId(todoId: string) {
    // Copia l'ID del todo negli appunti
    navigator.clipboard
      .writeText(todoId)
      .then(() => {
        console.log('ID del todo copiato con successo: ', todoId);
        //alert('ID del todo copiato con successo: ' + todoId);
      })
      .catch((error) => {
        console.error("Errore durante la copia dell'ID del todo: ", error);
        //alert("Errore durante la copia dell'ID del todo");
      });
  }

  description = false; // Dichiarazione della proprietà 'description' con inizializzazione
}
