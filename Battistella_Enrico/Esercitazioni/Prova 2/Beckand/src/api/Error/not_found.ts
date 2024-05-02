import { Request, Response, NextFunction } from "express";

export class NotFoundError extends Error {
  // Il costruttore della classe NotFoundError
  constructor() {
    // Chiama il costruttore della classe genitore (Error) con il messaggio 'Entity not found'
    super("Entity not found");
  }
}

// Definisce una funzione middleware notFoundHandler per gestire gli errori di tipo NotFoundError
export const notFoundHandler = (
  err: Error,
  req: Request,
  res: Response,
  next: NextFunction
) => {
  // Verifica se l'errore ricevuto è un'istanza di NotFoundError
  if (err instanceof NotFoundError) {
    res.status(404); // Se è not found imposta lo status a 404
    res.json({
      error: "NotFoundError", // Indica che si è verificato un errore di tipo NotFoundError
      message: "Entity not found", // Messaggio che descrive l'errore
    });
  } else {
    next(err); // Altrimenti, passa l'errore al middleware successivo
  }
};
