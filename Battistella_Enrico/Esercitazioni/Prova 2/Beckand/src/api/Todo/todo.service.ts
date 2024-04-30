import mongoose from "mongoose";
import { User } from "../User/user.entity";
import { UserModel } from "../User/user.model";
import { task_entity as Todo } from "./todo.entity";
import { TodoModel } from "./todo.model";

export class TodoService {
  async show_todo(userId: string): Promise<Todo[]> {
    try {
      // Utilizza il modello TodoModel per cercare i todo associati all'utente specificato
      const todos = await TodoModel.find({ createdBy: userId })
        .populate("createdBy")
        .populate("assignedTo");
      return todos; // Restituisce i todo trovati
    } catch (error) {
      throw new Error(`Errore durante l'elenco dei todo: ${error}`); // Gestisci eventuali errori
    }
  }

  //Partial è un tipo di TypeScript che crea un nuovo tipo con tutti i campi di un altro tipo impostati come obbligatori.
  async add_todo(TodoObject, userId): Promise<Todo> {
    try {
      // Crea un nuovo todo utilizzando il modello TodoModel
      const newTodo = await TodoModel.create({
        ...TodoObject,
        userId,
      });

      // Restituisci il nuovo todo appena creato
      return newTodo;
    } catch (error) {
      throw new Error(`Errore durante l'aggiunta del todo: ${error}`);
    }
  }

  async check_todo(id: string) {
    try {
      // Trova il todo con l'id specificato
      const todo = await TodoModel.findById(id);

      // Se il todo non è stato trovato, restituisci un errore 404
      if (!todo) {
        throw new Error("Todo non trovato");
      }

      todo.completed = true;
      await todo.save();

      return todo;
    } catch (error) {
      // Gestisci eventuali errori
      throw new Error(`Impossibile aggiornare il todo: ${error}`);
    }
  }

  async uncheck_todo(id: string) {
    try {
      // Trova il todo con l'id specificato
      const todo = await TodoModel.findById(id);

      // Se il todo non è stato trovato, restituisci un errore 404
      if (!todo) {
        throw new Error("Todo non trovato");
      }

      todo.completed = false;
      await todo.save();

      return todo;
    } catch (error) {
      // Gestisci eventuali errori
      throw new Error(`Impossibile aggiornare il todo: ${error}`);
    }
  }
}
export default new TodoService();
