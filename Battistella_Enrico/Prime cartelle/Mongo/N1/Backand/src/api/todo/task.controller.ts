// Moduli npm
import { Request, Response, NextFunction, query } from "express";
import mongoose from "mongoose";

// Moduli locali
import { task_model } from "./task.model";
import { NotFoundError } from "../../errors/not-found";
import { crea_task_dto } from "./task.dto";
import { TypedRequest } from "../../utils/typed-request.interface";
import TaskService from "./task.service";

// Mostra task
export const mostra_task = async (
  req: Request,
  res: Response,
  next: NextFunction
) => {
  const mostra_completi = req.query.completed === "true";
  const query = mostra_completi ? {} : { completed: false };
  try {
    const task = await TaskService.listTask(query);
    res.status(200).json(task);
  } catch (error) {
    res.status(500).json({
      errore: "InternalServerError",
      messaggio: "Il server ha riscontrato un errore interno.",
    });
    next(error);
  }
};
// Metodo GET /api/todo
// req.query = { "mostra_completi": "true/false" }

// Aggiungi task
export const aggiungi_task = async (
  req: TypedRequest<crea_task_dto>,
  res: Response,
  next: NextFunction
) => {
  const { title, dueDate } = req.body;
  try {
    const task = await TaskService.addTask(title, dueDate);
    res.status(201).json(task);
  } catch (error) {
    res.status(500).json({
      errore: "InternalServerError",
      messaggio: "Il server ha riscontrato un errore interno.",
    });
    next(error);
    console.error(error);
  }
};
// Metodo POST /api/todo
// req.query = { "titolo": "titolo del task", "scadenza": "2021-12-31" }

// Funzione per controllare lo stato di completamento di un task
export const setta_completato = async (
  req: Request,
  res: Response,
  next: NextFunction
) => {
  try {
    //const task = await task_model.findById(req.params.id);
    const task = await TaskService.ceckTask(req.params.id);

    if (!task) throw new NotFoundError();

    await task.save();
    res.status(200).json(task);
  } catch (error) {
    if (error instanceof mongoose.Error) {
      res.status(500).json({
        errore: "DatabaseError",
        messaggio: "Errore durante l'interazione con il database.",
      });
    } else {
      res.status(500).json({
        errore: "InternalServerError",
        messaggio: "Il server ha riscontrato un errore interno.",
      });

      next(error);
      console.log(error);
    }
  }
};

export const setta_non_completato = async (
  req: Request,
  res: Response,
  next: NextFunction
) => {
  try {
    //const task = await task_model.findById(req.params.id);
    const task = await TaskService.unceckTask(req.params.id);

    if (!task) throw new NotFoundError();

    await task.save();

    res.status(200).json(task);
  } catch (error) {
    if (error instanceof mongoose.Error) {
      res.status(500).json({
        errore: "DatabaseError",
        messaggio: "Errore durante l'interazione con il database.",
      });
    } else {
      res.status(500).json({
        errore: "InternalServerError",
        messaggio: "Il server ha riscontrato un errore interno.",
      });
    }
    next(error);
    console.log(error);
  }
};
// Metodo PATCH /api/todo/:id
// req.query = { "completato": "true/false" }
