import { Component, Input, OnInit } from '@angular/core';
import { Todo } from '../../entity/todo.entity';

@Component({
  selector: 'app-todo-card',
  templateUrl: './todo.card.component.html',
  styleUrls: ['./todo.card.component.css'],
})
export class TodoCardComponent implements OnInit {
  @Input() todos: Todo[] = []; // Dichiarazione della proprietà 'todos' come input con inizializzazione
  today: Date = new Date();
  expiredDays: number = 0;

  ngOnInit(): void {
    console.log('Lista dei todo:', this.todos);

    setInterval(() => {
      this.today = new Date();
    }, 60000); // 60000 millisecondi corrispondono a 1 minuto
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
        console.error("Errore durante la copia dell'ID del todo: ", todoId, error);
        //alert("Errore durante la copia dell'ID del todo");
      });
  }

  isExpired(dueDate: Date): boolean {
    if (!dueDate) return false; // Non è stata specificata una data di scadenza
    dueDate = new Date(dueDate); // Converto la data di scadenza in un oggetto Date

    const millisecondsInDay = 1000 * 60 * 60 * 24; // Millisecondi in un giorno
    const differenceInMilliseconds = this.today.getTime() - dueDate.getTime(); // Differenza in millisecondi tra le due date
    const differenceInDays = Math.floor(differenceInMilliseconds / millisecondsInDay); // Differenza in giorni
    //console.log('Differenza in giorni:', differenceInDays);
    this.expiredDays = differenceInDays;

    return dueDate < this.today; // Ritorna true se la data di scadenza è passata rispetto alla data odierna
  }

  description = false; // Dichiarazione della proprietà 'description' con inizializzazione
}
