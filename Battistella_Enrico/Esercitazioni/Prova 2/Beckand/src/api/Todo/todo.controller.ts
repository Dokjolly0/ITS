import mongoose from "mongoose";
import { task_entity } from "./todo.entity";
import TodoService from "./todo.service";
import { Request, Response, NextFunction } from "express";
import { NotFoundError } from "../Error/not_found";
import { Add_todo_dto } from "./todo.dto";
import { TypedRequest } from "../../utils/typed-request";
import { ne } from "@faker-js/faker";

export const show_todo = async (
  req: Request,
  res: Response,
  next: NextFunction
) => {
  try {
    const user = req.user!;
    const todo = await TodoService.show_todo(user.id!);
    res.json(todo);
  } catch (err) {
    next(err);
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

    // Aggiungi il todo utilizzando il service TodoService
    const newTodo = await TodoService.add_todo(
      title,
      dueDate,
      user.id!,
      assignedTo
    );

    // Invia il nuovo todo aggiunto come risposta
    res.json(newTodo);
  } catch (err) {
    next(err);
  }
};

export const check_todo = async (
  req: Request,
  res: Response,
  next: NextFunction
) => {
  try {
    const todo = await TodoService.check_todo(req.params.id);
    await todo!.save();
    res.status(200).json(todo);
  } catch (err) {
    res.status(500).json({
      errore: "InternalServerError",
      messaggio: "Il server ha riscontrato un errore interno.",
    });
    console.error(err);
    next(err);
  }
};

export const uncheck_todo = async (
  req: Request,
  res: Response,
  next: NextFunction
) => {
  try {
    const todo = await TodoService.uncheck_todo(req.params.id);
    await todo!.save();
    res.status(200).json(todo);
  } catch (err) {
    res.status(500).json({
      errore: "InternalServerError",
      messaggio: "Il server ha riscontrato un errore interno.",
    });
    console.error(err);
    next(err);
  }
};
