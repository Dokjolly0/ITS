// import { Component } from '@angular/core';
// import { TodoService } from '../../services/todo.service';
// import { Todo } from '../../entity/todo.entity';

// @Component({
//   selector: 'app-check-todos',
//   templateUrl: './check-todos.component.html',
//   styleUrl: './check-todos.component.css',
// })
// export class CheckTodosComponent {
//   constructor(private todoService: TodoService) {}
//   token = localStorage.getItem('token');
//   todos: Todo[] = [];

//   // onSubmitSearch() {
//   //   const title = (document.querySelector('#title') as HTMLInputElement)?.value;

//   //   if (!this.token) {
//   //     console.error('Nessun token disponibile.');
//   //     return;
//   //   }

//   //   this.todoService.getTodoByTitle(this.token, title).subscribe(
//   //     (response: any) => {
//   //       if (!response) {
//   //         console.log('La risposta non contiene la lista dei todo:', response);
//   //         return;
//   //       }
//   //       if (!response.todos) {
//   //         console.log('La risposta non è un todo:', response, this.todos);
//   //         this.todos = response;
//   //         return;
//   //       }
//   //       // Assegna solo se la risposta contiene la lista dei todo
//   //       this.todos = response.todos;
//   //       console.log('Lista dei todo:', this.todos);
//   //     },
//   //     (error: any) => {
//   //       console.error(
//   //         'Errore durante il recupero della lista dei todo:',
//   //         error
//   //       );
//   //     }
//   //   );
//   // }

//   // onSubmit() {
//   //   const id_todo = (document.querySelector('#submit') as HTMLInputElement)
//   //     .value;
//   //   console.log('id_todo:', id_todo);

//   //   if (!this.token) {
//   //     console.error('Nessun token disponibile.');
//   //     return;
//   //   }

//   //   this.todoService.setCompleted(this.token, id_todo).subscribe(
//   //     (response: any) => {
//   //       console.log('Todo settato completato:', response);
//   //     },
//   //     (error: any) => {
//   //       console.error('Errore durante il completamento del todo:', error);
//   //     }
//   //   );
//   // }
//   onSubmit() {}
//   onSubmitSearch() {}
// }
