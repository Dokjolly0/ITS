import { Task } from "./task.entity";
import mongoose from "mongoose";

const task_schema = new mongoose.Schema<Task>({
  title: { type: String, required: true },
  dueDate: Date,
  completed: { type: Boolean, default: false },
});

task_schema.virtual("expired").get(function (this: Task) {
  return this.dueDate && !this.completed && this.dueDate < new Date();
});

task_schema.set("toJSON", {
  virtuals: true,
  transform: (_, ret) => {
    ret.id = ret._id;
    delete ret._id;
    delete ret.__v;

    return ret;
  },
});

export const task_model = mongoose.model<Task>("Task", task_schema);
