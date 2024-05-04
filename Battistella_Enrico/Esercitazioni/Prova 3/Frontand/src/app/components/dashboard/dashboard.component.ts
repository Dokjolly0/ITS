import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css'],
})
export class DashboardComponent implements OnInit {
  constructor() {}

  ngOnInit(): void {
    // Esegui qui eventuali operazioni di inizializzazione
  }

  onClickViewTodo(): void {
    alert('Hai cliccato sul pulsante "Visualizza Todo"');
  }

  onClickAddTodo(): void {
    alert('Hai cliccato sul pulsante "Aggiungere un Todo"');
  }

  onClickFlagCompleted(): void {
    alert('Hai cliccato sul pulsante "Flagga Completato"');
  }

  onClickFlagIncomplete(): void {
    alert('Hai cliccato sul pulsante "Flagga Non Completato"');
  }
}
console.log('Script caricato');

// onClickViewTodo(): void {
//   alert('Hai cliccato sul pulsante "Visualizza Todo"');
// }

// onClickAddTodo(): void {
//   alert('Hai cliccato sul pulsante "Aggiungere un Todo"');
// }

// onClickFlagCompleted(): void {
//   alert('Hai cliccato sul pulsante "Flagga Completato"');
// }

// onClickFlagIncomplete(): void {
//   alert('Hai cliccato sul pulsante "Flagga Non Completato"');
// }
