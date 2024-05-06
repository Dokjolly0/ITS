import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { UserService } from '../../services/user.service';
import { TodoService } from '../../services/todo.service';
import { User } from '../../entity/user.entity';

@Component({
  selector: 'app-add-todo',
  templateUrl: './add-todo.component.html',
  styleUrl: './add-todo.component.css',
})
export class AddTodoComponent implements OnInit {
  availableUsers: string[] = [];
  token = localStorage.getItem('token');
  user = localStorage.getItem('user');

  @Output() formSubmitted = new EventEmitter<void>();

  constructor(
    private userService: UserService,
    private todoService: TodoService
  ) {} // Inietta il servizio TodoService nel costruttore

  ngOnInit(): void {
    this.getUserList(); // Chiama il metodo per ottenere la lista degli utenti disponibili
  }

  getUserList(): void {
    const token = localStorage.getItem('token');
    if (!token) {
      console.error('Nessun token disponibile.');
      return; // Esci dalla funzione se il token non è presente
    }

    this.userService.getUserList(token).subscribe(
      (response: any) => {
        if (!response || !response.users) {
          console.log(
            'La risposta non contiene la lista degli utenti:',
            response
          );
          this.availableUsers = response; // Assegna la risposta all'array degli utenti disponibili
          // Estrai solo la proprietà fullName da ciascun oggetto
          // Estrai la proprietà fullName da ciascun oggetto e crea un array con i nomi completi
          this.availableUsers = response.map((user: any) => user.fullName);
          return; // Esci dalla funzione se la risposta non contiene la lista degli utenti
        }
        this.availableUsers = response.users;
        // Estrai la proprietà fullName da ciascun oggetto e crea un array con i nomi completi
        this.availableUsers = response.map((user: any) => user.fullName);
        console.log('Lista degli utenti:', this.availableUsers);
      },
      (error: any) => {
        console.error(
          'Errore durante il recupero della lista degli utenti:',
          error
        );
      }
    );
  }

  todo: any = {
    title: '',
    description: '',
    dueDate: '',
    createBy: JSON.parse(this.user!),
    assignedTo: '',
  };

  onSubmit() {
    const value = '';
    console.log('(add)Dati del form:', this.todo);
    this.todoService.setSharedData(this.todo); // Condividi i dati del form con il servizio TodoService
    this.formSubmitted.emit(); // Emit an event to notify parent component
    console.log(this.todo);

    //#region Trova l'id dell'utente per fare assignedTo
    const fullName_assignedTo = (
      document.querySelector('#assignedTo') as HTMLSelectElement
    ).value;
    if (fullName_assignedTo) {
      // Effettua la ricerca dell'utente per il nome completo
      this.todoService
        .findUserByFullName(this.token!, fullName_assignedTo)
        .subscribe(
          (user: any) => {
            this.todo.assignedTo = user.id; // Assegna l'id dell'utente trovato alla proprietà assignedTo del todo
            this.todo.assignedTo = value;

            // Questa funzione verrà eseguita quando l'observable emetterà un valore
            console.log(`Valore assignTo: ${this.todo.assignedTo}`);
            console.log('Todo trovato:', this.todo);
            // Puoi fare qualsiasi altra operazione qui con l'utente trovato
          },
          (error: any) => {
            // Questa funzione verrà eseguita se si verifica un errore durante la chiamata
            this.todo.assignedTo = undefined; // Assegna undefined alla proprietà assignedTo del todo
            console.log('Non hai scelto nessun utente');
          }
        );
    }
    console.log('assignedTo:', this.todo);

    //Titolo
    const title = (document.querySelector('#title') as HTMLInputElement).value;
    if (title) this.todo.title = title;
    else {
      alert('Inserisci un titolo');
      return;
    }

    //Descrizione
    const description = (
      document.querySelector('#description') as HTMLInputElement
    ).value;
    if (description) this.todo.description = description;
    else this.todo.description = undefined;

    //Data di scadenza
    const dueDate = (document.querySelector('#dueDate') as HTMLInputElement)
      .value;
    if (dueDate) this.todo.dueDate = dueDate;
    else this.todo.dueDate = undefined;

    //#endregion
    console.log('Dati del form:', this.todo);
    this.todoService.addTodo(this.token!, this.todo).subscribe(
      (response: any) => {
        console.log('Todo aggiunto:', response);
        this.formSubmitted.emit(); // Emit an event to notify parent component
      },
      (error: any) => {
        console.error("Errore durante l'aggiunta del todo:", error);
        console.log(`Todo con errore: `, this.todo);
      }
    );
  }
}
