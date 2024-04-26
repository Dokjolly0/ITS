import mongoose from "mongoose";
import TodoService from "./todo.service";
import { Request, Response, NextFunction } from "express";

export const show_todo = async (
  req: Request,
  res: Response,
  next: NextFunction
) => {
  try {
    const completed = req.query.show_completed === "true"; // Converte il valore in booleano
    const todos = await TodoService.show_todo(completed);
    console.log(todos);
    res.status(200).json(todos);
  } catch (err) {
    console.error(err);
    res.status(500).json({
      errore: "InternalServerError",
      messaggio: "Il server ha riscontrato un errore interno.",
    });
    next(err);
  }
};

export const add_todo = async (
  req: Request,
  res: Response,
  next: NextFunction
) => {
  const { title, dueDate } = req.body;
  try {
    const todo = await TodoService.add_todo(title, dueDate);
    res.status(201).json(todo);
  } catch (err) {
    res.status(500).json({
      errore: "InternalServerError",
      messaggio: "Il server ha riscontrato un errore interno.",
    });
    console.error(err);
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
