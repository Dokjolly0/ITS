import { task_entity as Todo } from "./todo.entity";
import { TodoModel } from "./todo.model";

export class TodoService {
  async show_todo(show_completed) {
    let query = {}; //Oggetto di query
    // Se show_completed è true, includiamo tutti i todo
    if (show_completed === true || show_completed === "true") {
      query = {}; // Nessun filtro aggiunto (tutti i todo)
    } else {
      query = { completed: false }; // Filtro per completed = false (solo quelli da cpmpletare)
    }
    const todos = await TodoModel.find(query);
    return todos;
  }

  async add_todo(title: string, dueDate: Date) {
    const todo = await TodoModel.create({ title, dueDate });
    return todo;
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
