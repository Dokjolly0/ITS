import { Component, OnInit } from '@angular/core';
import { Todo } from '../../entity/todo.entity';
import { TodoService } from '../../services/todo.service';
import { UserService } from '../../services/user.service';

@Component({
  selector: 'app-assigned-to',
  templateUrl: './assigned-to.component.html',
  styleUrl: './assigned-to.component.css',
})
export class AssignedToComponent implements OnInit {
  todos: Todo[] = [];
  availableUsers: string[] = [];
  todo: any = {};
  isView = false;
  isAdd = false;
  isCheck = true;
  isUncheck = false;
  completed: boolean = true;
  id: string = '';
  title: string = '';
  token = localStorage.getItem('token');
  userToAssign = '';
  constructor(
    private todoService: TodoService,
    private userService: UserService
  ) {}

  ngOnInit(): void {
    this.getUserList();
  }

  getUserList(): void {
    if (!this.token) return; // Esci dalla funzione se il token non è presente

    this.userService.getUserList(this.token).subscribe(
      (response: any) => {
        if (!response || !response.users) {
          console.log(
            'La risposta non contiene la lista degli utenti:',
            response
          );
          // Estrai la proprietà fullName da ciascun oggetto e crea un array con i nomi completi
          this.availableUsers = response.map((user: any) => user.fullName);
          //esci dalla funzione se la risposta non contiene la lista degli utenti
          return;
        }
        this.availableUsers = response.users;
        // Estrai la proprietà fullName da ciascun oggetto e crea un array con i nomi completi
        this.availableUsers = response.map((user: any) => user.fullName);
        // console.log('Lista degli utenti:', this.availableUsers);
      },
      (error: any) => {
        console.error(
          'Errore durante il recupero della lista degli utenti:',
          error
        );
      }
    );
  }

  searchAll(): void {
    this.isView = false;
    this.isAdd = false;
    this.isCheck = true;
    this.isUncheck = false;

    // Assume che il token sia già disponibile come una stringa
    const token = localStorage.getItem('token');

    // Chiama il metodo getTodo del servizio TodoService passando il token
    this.todoService.getTodo(token!, this.completed).subscribe(
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
        console.error(
          'Errore durante il recupero della lista dei todo:',
          error
        );
      }
    );
  }

  onComplete(statusTodo: boolean) {
    this.id = (document.getElementById('submit') as HTMLInputElement).value;

    this.todoService.updateTodo(this.token!, this.id, statusTodo).subscribe(
      (response: any) => {
        console.log('Todo aggiornato:', response);

        // Svuota l'array todos
        this.todos = [];

        // Aggiungi il todo aggiornato all'array vuoto
        this.todos.push(response);
      },
      (error: any) => {
        //console.error("Errore durante l'aggiornamento del todo:", error);
        alert('Id non trovato');
      }
    );
  }

  getData() {
    const userToAssign = (
      document.getElementById('idAssignSelect') as HTMLSelectElement
    ).value;
    this.id = (document.getElementById('id') as HTMLInputElement).value;
    console.log('Valore di userToAssign:', userToAssign); // Aggiungi questo console.log
    if (userToAssign === '') {
      alert('Seleziona un utente per assegnare il todo.');
      return;
    } else if (this.id === '') {
      alert('Inserisci un id valido.');
      return;
    } else if (this.id === '' && userToAssign === '') {
      alert(
        'Inserisci un id valido e seleziona un utente per assegnare il todo.'
      );
    }
    this.userToAssign = userToAssign;
  }
  onAssign() {
    this.getData();

    this.todoService.getById(this.token!, this.id).subscribe(
      (response: any) => {
        console.log('Todo recuperato:', response);
        this.todo = response;
        this.todoService
          .findUserByFullName(this.token!, this.userToAssign)
          .subscribe(
            (user: any) => {
              this.userToAssign = user.id;
              console.log('Todo da assegnare:', this.userToAssign);
              this.todoService
                .assignTodo(this.id, this.userToAssign, this.token!)
                .subscribe(
                  (response: any) => {
                    console.log('Operazione completata:', response);
                    this.todos.push(response);
                  },
                  (error: any) => {
                    console.error(
                      "Errore durante l'assegnazione del todo: ",
                      error
                    );
                    console.log(
                      'Id: ',
                      this.id,
                      'UserToAssign: ',
                      this.userToAssign
                    );
                  }
                );
            },
            (error: any) => {
              console.error("Errore durante il recupero dell'utente:", error);
            }
          );
        console.log('Todo da assegnare:', this.todo);
      },
      (error: any) => {
        console.error('Errore durante il recupero del todo:', error);
      }
    );
    this.todo = [];
    this.todos = this.todo;
  }
}
