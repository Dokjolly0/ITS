import { task_model } from "./task.model";

export class TaskService {
  async listTask(completed) {
    const task = await task_model.find(completed);
    return task;
  }
  async addTask(title: string, dueDate: Date) {
    const task = await task_model.create({ title, dueDate });
    return task;
  }
  async ceckTask(id: string) {
    const task = await task_model.findById(id);
    task!.completed = true;
    return task;
  }
  async unceckTask(id: string) {
    const task = await task_model.findById(id);
    task!.completed = false;
    return task;
  }
  //   errorTask(res, error, next) {
  //     res.status(500).json({
  //       errore: "InternalServerError",
  //       messaggio: "Il server ha riscontrato un errore interno.",
  //     });
  //     next(error);
  //     console.error(error);
  //   }
}

export default new TaskService();
