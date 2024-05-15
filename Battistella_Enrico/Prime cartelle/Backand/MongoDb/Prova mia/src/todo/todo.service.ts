import { Todo } from "./todo.entity";
import { TodoModel } from "./todo.model";

export class TodoService {
  async getAll(): Promise<Todo[]> {
    // Recupera tutti i todo dal database
    return TodoModel.find().exec();
  }
  async getCompleted(): Promise<Todo[]> {
    // Recupera tutti i todo completati dal database
    return TodoModel.find({ completed: true }).exec();
  }
  async getById(id: string): Promise<Todo | null> {
    // Recupera un todo dal database per ID
    const todo = await TodoModel.findById(id).exec();
    if (!todo) {
      return null;
    }
    return todo;
  }
  async create(todo: Todo): Promise<Todo> {
    // Verifica se esiste già un todo con lo stesso ID
    const existingTodo = await TodoModel.findOne({ id: todo.id }).exec();
    if (existingTodo) {
      throw new Error("Todo already exists");
    }
    // Crea un nuovo todo
    const newTodo = await TodoModel.create(todo);
    return (await this.getById(newTodo.id))!;
  }
  async unceck(id: string): Promise<Todo | null> {
    // Recupera un todo dal database per ID
    const todo = await TodoModel.findById(id).exec();
    if (!todo) {
      return null;
    }
    // Imposta il todo come non completato
    todo.completed = false;
    await todo.save();
    return todo;
  }
  async check(id: string): Promise<Todo | null> {
    const todo = await TodoModel.findById(id).exec();
    if (!todo) {
      return null;
    }
    // Imposta il todo come completato
    todo.completed = true;
    await todo.save();
    return todo;
  }
}

export default new TodoService();
