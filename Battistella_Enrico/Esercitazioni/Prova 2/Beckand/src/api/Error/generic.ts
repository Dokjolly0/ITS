import { Request, Response, NextFunction } from "express";

export const genericHandler = (
  err: Error,
  req: Request,
  res: Response,
  next: NextFunction
) => {
  console.error(err); // Stampa l'errore sulla console per il debug
  res.status(500); // Imposta lo stato della risposta a 500 per indicare un errore interno del server
  res.json({
    // Invia una risposta JSON che contiene i dettagli dell'errore
    error: "InternalServerError", // Indica che si è verificato un errore interno del server
    message: "The server encountered an internal error", // Messaggio che descrive l'errore
  });
};
