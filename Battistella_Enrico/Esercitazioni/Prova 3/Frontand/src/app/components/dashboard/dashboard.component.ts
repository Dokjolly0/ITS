import {
  Component,
  OnInit,
  OnChanges,
  SimpleChanges,
  ViewChild,
  ElementRef,
} from '@angular/core';
import { AuthService } from '../../services/auth.service';
import { TodoService } from '../../services/todo.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css'],
})
export class DashboardComponent implements OnInit {
  fullName: string = '';
  isChecked: boolean = false; // Dichiarazione della variabile isChecked come variabile di istanza
  @ViewChild('completedCheckbox')
  completedCheckbox!: ElementRef<HTMLInputElement>;

  constructor(
    private authService: AuthService,
    private todoService: TodoService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.fullName = this.todoService.getUserFullName();
  }

  ngAfterViewInit(): void {
    const checkboxElement: HTMLInputElement =
      this.completedCheckbox.nativeElement;

    checkboxElement.addEventListener('change', () => {
      // Aggiorna la variabile isChecked quando lo stato del checkbox cambia
      this.isChecked = checkboxElement.checked;
      console.log('Checkbox selezionato:', this.isChecked);
    });
  }

  // Metodi per gestire i clic sui pulsanti
  onClickViewTodo(): void {
    // Assume che il token sia già disponibile come una stringa
    const token = localStorage.getItem('token');

    // Chiama il metodo getTodo del servizio TodoService passando il token
    this.todoService.getTodo(token!, this.isChecked).subscribe(
      (response: any) => {
        // Gestisci la risposta qui
        console.log('Risultati ottenuti da getTodo:', response);
      },
      (error: any) => {
        // Gestisci gli errori qui, se necessario
        console.error('Errore durante il recupero dei todo:', error);
      }
    );
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

  logout(): void {
    this.authService.logout();
    this.router.navigate(['/']);
  }
}
console.log('Script caricato');
