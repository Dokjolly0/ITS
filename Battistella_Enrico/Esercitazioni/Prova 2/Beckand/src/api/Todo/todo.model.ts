import { task_entity as Todo } from "./todo.entity";
import mongoose from "mongoose";

const todo_schema = new mongoose.Schema<Todo>({
  id: String,
  title: { type: String, required: true },
  dueDate: { type: Date, required: true },
  completed: { type: Boolean, default: false },
  createdBy: {
    type: {
      id: { type: String, required: true },
      firstName: { type: String, required: true },
      lastName: { type: String, required: true },
      fullName: { type: String, required: true },
      picture: { type: String, required: true },
    },
    required: false,
  },
  assignedTo: {
    type: {
      id: { type: String, required: true },
      firstName: { type: String, required: true },
      lastName: { type: String, required: true },
      fullName: { type: String, required: true },
      picture: { type: String, required: true },
    },
    required: false,
  },
});

todo_schema.virtual("expired").get(function (this: Todo) {
  const data_corrente = new Date();
  //Solo quando la data dueDate è scaduta il campo expired risultera true, altrimenti non risulta
  if (this.dueDate < data_corrente) return true;
});

todo_schema.set("toJSON", {
  virtuals: true,
  transform: function (doc, ret) {
    // Estrai l'ID dalla struttura dell'oggetto _id
    const id = ret._id ? ret._id.toString() : null;

    console.log("Valore di _id:", ret._id);
    console.log("Valore di __v:", ret.__v);

    const orderedFields = {
      id: id, // Utilizza l'ID estratto
      title: ret.title,
      dueDate: ret.dueDate,
      completed: ret.completed,
      expired: ret.expired,
    };

    if (ret._id) {
      delete ret._id; // Elimina _id dall'oggetto JSON
      console.log("_id eliminato");
    }
    if (ret.__v !== undefined) {
      delete ret.__v; // Elimina __v dall'oggetto JSON solo se è presente
      console.log("__v eliminato");
    }

    console.log("Oggetto JSON senza _id e __v:", orderedFields);

    return orderedFields;
  },
});

export const TodoModel = mongoose.model<Todo>("Todo", todo_schema);
// 'Todo' Il nome della collezione nel database MongoDB, che è 'Todo'
// todo_schema Lo schema Mongoose 'todo_schema', che definisce la struttura dei documenti nella collezione
// <Todo> Il tipo di dati TypeScript associato al modello, che sembra essere un tipo generico 'Todo'
