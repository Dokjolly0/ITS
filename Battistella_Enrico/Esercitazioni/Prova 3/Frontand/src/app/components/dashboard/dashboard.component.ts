import {
  Component,
  OnInit,
  OnChanges,
  SimpleChanges,
  ViewChild,
  ElementRef,
  Input,
} from '@angular/core';
import { AuthService } from '../../services/auth.service';
import { TodoService } from '../../services/todo.service';
import { Todo } from '../../entity/todo.entity';
import { Router } from '@angular/router';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css'],
})
export class DashboardComponent implements OnInit {
  fullName: string = '';
  isChecked: boolean = false;
  todos: Todo[] = [];
  isAdd: boolean = false;

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
      //console.log('Checkbox selezionato:', this.isChecked);
    });
  }

  // Metodi per gestire i clic sui pulsanti
  onClickViewTodo(): void {
    this.isAdd = false;
    // Assume che il token sia già disponibile come una stringa
    const token = localStorage.getItem('token');

    // Chiama il metodo getTodo del servizio TodoService passando il token
    this.todoService.getTodo(token!, this.isChecked).subscribe(
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

  onClickAddTodo(): void {
    this.isAdd = true;
    this.todos = [];
  }

  onClickFlagCompleted(): void {
    this.isAdd = false;
    alert('Hai cliccato sul pulsante "Flagga Completato"');
    this.todos = [];
  }

  onClickFlagIncomplete(): void {
    this.isAdd = false;
    alert('Hai cliccato sul pulsante "Flagga Non Completato"');
    this.todos = [];
  }

  logout(): void {
    this.authService.logout();
    this.router.navigate(['/']);
  }
}
console.log('Script caricato');
