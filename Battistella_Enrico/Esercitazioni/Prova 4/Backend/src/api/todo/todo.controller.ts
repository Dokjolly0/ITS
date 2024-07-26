import mongoose from "mongoose";
import TodoService from "./todo.service";
import { Request, Response, NextFunction } from "express";
import { Add_todo_dto, Check_todo_dto } from "./todo.dto";
import { TypedRequest } from "../../utils/typed-request";
import { UtenteNonTrovatoError } from "../../errors/user_not_found";

export const list = async (req: Request, res: Response, next: NextFunction) => {
  try {
    const user = req.user!; //console.log("user", user);
    let showCompleted =
      !!req.query.showCompleted &&
      (req.query.showCompleted as string).toLowerCase() === "true"; // Prende il valore di showCompleted nella query, se è true la variabile torna true, se no false
    let todos = await TodoService.showTodo(user.id!, showCompleted);
    res.json(todos);
  } catch (err) {
    next(err);
  }
};

export const add = async (
  req: TypedRequest<Add_todo_dto>,
  res: Response,
  next: NextFunction
) => {
  try {
    const user = req.user!;
    const newTodo = await TodoService.addTodo(req.body, user.id!);
    res.status(201).json(newTodo);
  } catch (err) {
    next(err);
  }
};

export const check = async (
  req: TypedRequest<any, any, Check_todo_dto>,
  res: Response,
  next: NextFunction
) => {
  try {
    const todoId: string = req.params.id;
    const todo = await TodoService.checkTodo(todoId, true);
    res.status(200).json(todo);
  } catch (err) {
    //Se trova errori, li devi aggiungere nel dto e poi nel router  devi mettere validate(quel_dto)
    next(err);
  }
};

export const uncheck = async (
  req: TypedRequest<any, any, Check_todo_dto>,
  res: Response,
  next: NextFunction
) => {
  try {
    const todoId = req.params.id;
    const todo = await TodoService.checkTodo(todoId, false);
    await todo!.save();
    res.status(200).json(todo);
  } catch (err: any) {
    next(err);
  }
};

export const assign = async (
  req: Request,
  res: Response,
  next: NextFunction
) => {
  try {
    const user = req.user!;
    const { assignedTo } = req.body;
    const todoId = req.params.id;
    const todo = await TodoService.assignTodo(todoId, assignedTo, user.id!);
    await todo!.save();
    res.status(200).json(todo);
  } catch (err) {
    next(err);
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
