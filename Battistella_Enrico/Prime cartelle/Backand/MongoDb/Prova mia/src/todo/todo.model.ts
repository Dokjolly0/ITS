import mongoose from "mongoose";
import { Todo } from "./todo.entity";

const todoSchema = new mongoose.Schema({
  title: { type: String, required: true },
  dueDate: { type: Date, required: true },
  completed: { type: Boolean, required: true },
  expired: { type: Boolean },
});

todoSchema.set("toJSON", {
  transform: (doc: any, ret: any) => {
    ret.id = ret._id;
    delete ret._id;
    delete ret.__v;
  },
});

export const TodoModel = mongoose.model<Todo>("Todo", todoSchema);
