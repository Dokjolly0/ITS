import todoService from "./todo.service";
import { Todo } from "./todo.entity";
import { Request, Response, NextFunction } from "express";
import { validationResult } from "express-validator";
import { TodoDto } from "./todo.dto";

export const list = async (req: Request, res: Response, next: NextFunction) => {
  try {
    const todos = await todoService.getAll();
    res.json(todos);
  } catch (error) {
    next(error);
  }
};
export const create = async (
  req: Request,
  res: Response,
  next: NextFunction
) => {
  try {
    const errors = validationResult(req);
    if (!errors.isEmpty()) {
      return res.status(400).json({ errors: errors.array() });
    }
    const todo = req.body as Todo;
    const newTodo = await todoService.create(todo);
    res.status(201).json(newTodo);
  } catch (error) {
    next(error);
  }
};

export const check = async (
  req: Request,
  res: Response,
  next: NextFunction
) => {
  try {
    const id = req.params.id;
    const todo = await todoService.check(id);
    if (!todo) {
      return res.status(404).json({ message: "Todo not found" });
    }
    res.json(todo);
  } catch (error) {
    next(error);
  }
};

export const uncheck = async (
  req: Request,
  res: Response,
  next: NextFunction
) => {
  try {
    const id = req.params.id;
    const todo = await todoService.unceck(id);
    if (!todo) {
      return res.status(404).json({ message: "Todo not found" });
    }
    res.json(todo);
  } catch (error) {
    next(error);
  }
};
