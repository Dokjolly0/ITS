import mongoose from "mongoose";
import TodoService from "./todo.service";
import e, { Request, Response, NextFunction } from "express";
import { Add_todo_dto } from "./todo.dto";
import { TypedRequest } from "../../utils/typed-request";
import { UtenteNonTrovatoError } from "../../errors/user_not_found";

export const show_todo = async (
  req: Request,
  res: Response,
  next: NextFunction
) => {
  try {
    const user = req.user!;
    console.log("user", user);
    let completed: boolean | undefined = undefined;

    // Controlla se il parametro completed è definito e non è vuoto
    if (req.query.completed !== undefined && req.query.completed !== "") {
      completed = req.query.completed === "true"; // Converte la stringa in booleano
    }

    const todo = await TodoService.show_todo(user.id!, { completed });
    res.status(200).json(todo);
  } catch (error: any) {
    if (error.message === "User id non valido")
      res.status(400).json({ "Errore: ": "Iser id non valido" });
    else
      res.status(500).json({
        errore: "InternalServerError",
        messaggio:
          "Il server ha riscontrato un errore interno." + error.message,
      });
  }
};

export const add_todo = async (
  req: TypedRequest<Add_todo_dto>,
  res: Response,
  next: NextFunction
) => {
  try {
    const user = req.user!;
    const { title, dueDate, assignedTo } = req.body;
    const assignedToValue = assignedTo !== undefined ? assignedTo : undefined;

    const TodoObject = {
      title,
      dueDate,
      createdBy: user.id!,
      assignedTo: assignedToValue,
    };

    if (title === undefined) throw new Error("Il titolo è obbligatorio");

    const newTodo = await TodoService.add_todo(TodoObject, user.id!);

    res.status(201).json(newTodo);
  } catch (err: any) {
    if (err.message === "Il titolo è obbligatorio")
      res.status(400).json({ "Errore: ": "Il titolo è obbligatorio" });
    else if (err.message instanceof UtenteNonTrovatoError)
      res.status(400).json({ "Errore: ": "Utente non trovato" });
    else
      res.status(500).json({
        errore: "InternalServerError",
        messaggio: "Il server ha riscontrato un errore interno." + err.message,
      });
  }
};

export const check_todo = async (
  req: Request,
  res: Response,
  next: NextFunction
) => {
  try {
    const user = req.user!;
    const todoId = req.params.id;

    const todo = await TodoService.check_todo(todoId, user.id!);

    await todo!.save();
    res.status(200).json(todo);
  } catch (err: any) {
    if (err.message === "L'id che hai inserito non è valido")
      res
        .status(404)
        .json({ "Errore: ": "L'id che hai inserito non è valido" });
    //
    else if (err.message === "Todo non trovato")
      res.status(404).json({ "Errore: ": "Todo non trovato" });
    //
    else if (err.message === "Non hai accesso a questo todo")
      res.status(401).json({ "Errore: ": "Non hai accesso a questo todo" });
    //
    else if (err.message === "Il todo non esiste")
      res.status(404).json({ "Errore: ": "Il todo non esiste" });
    //
    else if (err instanceof mongoose.Error.CastError)
      res.status(500).json({
        "Errore ": "Errore di conversione dell'ID",
      });
    //
    else
      res.status(500).json({
        errore: "InternalServerError",
        messaggio: "Il server ha riscontrato un errore interno." + err.message,
      });
  }
};

export const uncheck_todo = async (
  req: Request,
  res: Response,
  next: NextFunction
) => {
  try {
    const user = req.user!;
    const todoId = req.params.id;

    const todo = await TodoService.uncheck_todo(todoId, user.id!);

    await todo!.save();
    res.status(200).json(todo);
  } catch (err: any) {
    if (err.message === "L'id che hai inserito non è valido")
      res
        .status(404)
        .json({ "Errore: ": "L'id che hai inserito non è valido" });
    else if (err.message === "Todo non trovato")
      res.status(404).json({ "Errore: ": "Todo non trovato" });
    else if (err.message === "Non hai accesso a questo todo")
      res.status(404).json({ "Errore: ": "Non hai accesso a questo todo" });
    else if (err.message === "Il todo non esiste")
      res.status(404).json({ "Errore: ": "Il todo non esiste" });
    else if (err instanceof mongoose.Error.CastError) {
      res.status(500).json({
        "Errore ": "Errore di conversione dell'ID",
      });
    } else {
      res.status(500).json({
        errore: "InternalServerError",
        messaggio: "Il server ha riscontrato un errore interno." + err.message,
      });
    }
  }
};

export const assign_todo = async (
  req: Request,
  res: Response,
  next: NextFunction
) => {
  try {
    const user = req.user!;
    const { assignedTo } = req.body;
    const todoId = req.params.id;
    const todo = await TodoService.assign_todo(todoId, assignedTo, user.id!);
    await todo!.save();
    res.status(200).json(todo);
  } catch (error: any) {
    if (error instanceof UtenteNonTrovatoError)
      //if (error.message === "Utente non trovato")
      res.status(404).json({ "Errore: ": "Utente non trovato" });
    else if (error.message === "Todo non trovato")
      res.status(404).json({ "Errore: ": "Todo non trovato" });
    else if (error.message === "L'id che hai inserito non è valido")
      res
        .status(404)
        .json({ "Errore: ": "L'id che hai inserito non è valido" });
    else if (error.message === "Il todo non esiste")
      res.status(404).json({ "Errore: ": "Il todo non esiste" });
    else if (error.message === "Non hai accesso a questo todo")
      res.status(401).json({ "Errore: ": "Non hai accesso a questo todo" });
    else {
      res.status(500).json({
        errore: "InternalServerError",
        messaggio: "Il server ha riscontrato un errore interno.",
      });
    }
  }
};

export const get_by_title = async (
  req: Request,
  res: Response,
  next: NextFunction
) => {
  try {
    const user = req.user!;
    const title = req.params.title as string;
    const todo = await TodoService.get_by_title(title, user.id!);
    console.log("todo", todo);
    res.status(200).json(todo);
    console.log(title, user.id);
  } catch (error: any) {
    if (error.message === "Todo non trovato")
      res.status(400).json({ "Errore: ": "Todo non trovato" });
    else
      res.status(500).json({ errore: "InternalServerError" + error.message });
  }
};

export const get_by_id = async (
  req: Request,
  res: Response,
  next: NextFunction
) => {
  try {
    const user = req.user!;
    const id = req.params.id as string;
    const todo = await TodoService.search_by_id(id, user.id!);
    console.log("todo", todo, "id", id);
    res.status(200).json(todo);
  } catch (error: any) {
    if (error.message === "Todo non trovato")
      res.status(400).json({ "Errore: ": "Todo non trovato" });
    else
      res.status(500).json({
        errore: "InternalServerError",
        messaggio:
          "Il server ha riscontrato un errore interno." + error.message,
      });
  }
};

export const delate_todo = async (
  req: Request,
  res: Response,
  next: NextFunction
) => {
  try {
    const user = req.user!;
    const id = req.params.id as string;
    const todo = await TodoService.delete_todo(id, user.id!);
    res.status(200).json({ "Todo eliminato correttamente": todo });
  } catch (error: any) {
    if (error.message === "Todo non trovato")
      res.status(400).json({ "Errore: ": "Todo non trovato" });
    else
      res.status(500).json({
        errore: "InternalServerError",
        messaggio:
          "Il server ha riscontrato un errore interno." + error.message,
      });
  }
};

export const update_date = async (
  req: Request,
  res: Response,
  next: NextFunction
) => {
  try {
    const user = req.user!;
    const id = req.params.id as string;
    const date = req.body.date as Date;
    const todo = await TodoService.update_date(id, user.id!, date);
    res.status(200).json(todo);
  } catch (error: any) {
    if (error.message === "Todo non trovato")
      res.status(400).json({ "Errore: ": "Todo non trovato" });
    else
      res.status(500).json({
        errore: "InternalServerError",
        messaggio:
          "Il server ha riscontrato un errore interno. " + error.message,
      });
  }
};
