import mongoose from "mongoose";
import { UserModel } from "../user/user.model";
import { task_entity as Todo } from "./todo.entity";
import { TodoModel } from "./todo.model";
import { UtenteNonTrovatoError } from "../../errors/user_not_found";
import { Add_todo_dto } from "./todo.dto";
import { NotFoundError } from "../../errors/not-found";

export class TodoService {
  //Funzione per filtrare todo completi e non completi
  async showTodo(userId: string, completed: boolean): Promise<Todo[]> {
    const option: any = {
      $or: [{ createdBy: userId }, { assignedTo: userId }],
    };
    if (!completed) option.completed = { $ne: true };
    let todos = await TodoModel.find(option)
      .sort({ dueDate: 1 })
      .populate("createdBy")
      .populate("assignedTo"); //console.log(todos);
    return todos;
  }

  //Partial è un tipo di TypeScript che crea un nuovo tipo con tutti i campi di un altro tipo impostati come obbligatori.
  async addTodo(TodoObject: Add_todo_dto, userId: string): Promise<Todo> {
    // const userAssign = await UserModel.findById(TodoObject.assignedTo);
    // if (!userAssign) throw new UtenteNonTrovatoError();

    const newTodo = await TodoModel.create({
      ...TodoObject,
      createdBy: userId, // Assegna direttamente l'ID dell'utente
    });
    return newTodo.populate("createdBy assignedTo"); // Esegui popolazione e restituisci il risultato
  }

  // Vale sia per Check che per Uncheck
  async checkTodo(todoId: string, completed: boolean) {
    const todo = await TodoModel.findById(todoId);
    // Sarebbe da togliere
    if (!todo) throw new NotFoundError();
    //Aggiungi la logica per garantire che solo chi ha creato il todo o a chi è assegnasto possano fare check/uncheck
    todo.completed = completed;
    await todo.save();
    return todo;
  }

  async assignTodo(
    id: string,
    assignedTo: mongoose.Types.ObjectId,
    userId: string
  ) {
    const todo = await TodoModel.findById(id); // Trova il todo con l'id specificato
    // Se il todo non è stato trovato, restituisci un errore 404
    if (!todo) throw new NotFoundError();
    // Verifica se l'id dell'utente assegnato è valido
    const isValidObjectId = mongoose.Types.ObjectId.isValid(assignedTo);
    if (!isValidObjectId) throw new Error("L'id che hai inserito non è valido");

    const assignedToUser = await UserModel.findById(assignedTo);
    // Verifica se l'utente assegnato esiste
    if (!assignedToUser) throw new UtenteNonTrovatoError();
    const isTodo = await TodoModel.findById(id);
    // Verifica se il todo esiste
    if (!isTodo) throw new Error("Il todo non esiste");

    console.log("AssignToUser", assignedToUser);

    // Verifica se l'utente che ha creato il todo è lo stesso che sta cercando di assegnarlo
    if (todo.createdBy.toString() === userId)
      todo.assignedTo = assignedToUser.id;
    else throw new Error("Non hai accesso a questo todo");

    //Aspetta che Popoli i campi createdBy e assignedTo
    await todo.populate("createdBy assignedTo");

    // Controlla se l'attributo assignedTo è stato modificato
    if (todo.isModified("assignedTo")) await todo.save();
    else console.log("Nessuna modifica all'assegnazione del todo.", todo);

    return todo;
  }

  async get_by_title(title: string, userId: string) {
    const regex = new RegExp(title, "i"); // 'i' indica una ricerca non case-sensitive
    const todo = await TodoModel.find({ title: regex, createdBy: userId })
      .populate("createdBy")
      .populate("assignedTo");
    if (!todo) throw new Error("Todo non trovato");
    console.log(todo);
    return todo;
  }

  async search_by_id(todoId: string, userId: string) {
    const todo = await TodoModel.findById(todoId)
      .populate("createdBy")
      .populate("assignedTo");
    if (!todo) throw new Error("Todo non trovato");
    if (todo.createdBy.id?.toString() !== userId)
      throw new Error("Non hai accesso a questo todo");
    return todo;
  }

  async delete_todo(todoId: string, userId: string) {
    // Verifica se l'utente è autorizzato a eliminare il todo
    const user = await UserModel.findById(userId);
    if (!user) throw new Error("Non sei autorizzato a eliminare questo todo");

    // Controlla se l'ID del todo è valido
    if (!mongoose.Types.ObjectId.isValid(todoId))
      throw new Error("L'id del todo non è valido");

    // Cerca il todo per ID
    const todo = await TodoModel.findOne({ _id: todoId });

    // Se il todo non è stato trovato, restituisci un errore
    if (!todo) throw new Error("Todo non trovato");

    // Verifica se l'utente che ha creato il todo è lo stesso che sta cercando di eliminarlo
    if (todo.createdBy.toString() !== userId)
      throw new Error("Non hai accesso a questo todo");

    // Elimina il todo dal database
    await TodoModel.deleteOne({ _id: todoId });

    // Restituisci il todo eliminato
    return todo;
  }

  async update_date(todoId: string, userId: string, date: Date) {
    const todo = await TodoModel.findById(todoId);
    if (!todo) throw new Error("Todo non trovato");
    if (todo.createdBy.toString() !== userId)
      throw new Error("Non hai accesso a questo todo");
    todo.dueDate = date;
    await todo.save();
    return todo;
  }
}
export default new TodoService();

//Crea una nuova classe di errore, la lancio nel servizio (new not_found_error) e la gestisco nel catch
