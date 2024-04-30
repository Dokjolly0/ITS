import { NextFunction, Request, Response } from "express";
import { ValidationError as OriginalValidationError } from "class-validator";

//Validation error
export class ValidationError extends Error {
  //Validation error //OriginalValidationError sono importati da npm
  originalErrors: OriginalValidationError[];
  constructor(errors: OriginalValidationError[]) {
    super(); //Ogni volta che trova un errore di validazione lo inserisce dentro l'array
    this.originalErrors = errors;
    this.name = "ValidationError";

    // Costruisce un messaggio concatenando i vincoli di validazione degli errori originali
    this.message = this.originalErrors
      .map((err) => {
        return Object.values(err.constraints as any);
      })
      .join("; ");
    //Prima li unisce in un array, poi li trasforma in stringa separandoli da ;
  }
}

export const validationErrorHandler = async (
  err: Error,
  res: Response,
  next: NextFunction
) => {
  // Verifica se l'errore è un'istanza di ValidationError
  if (err instanceof ValidationError) {
    // Se è un errore di validazione, imposta lo stato della risposta a 400
    res.status(400);
    // Invia una risposta JSON che contiene i dettagli dell'errore di validazione
    res.json({
      error: err.name,
      message: err.message,
      details: err.originalErrors.map((e) => ({
        property: e.property,
        constraints: e.constraints,
        value: e.value,
      })),
    });
  } else {
    // Se l'errore non è di tipo ValidationError, passa l'errore al middleware successivo
    next(err);
  }
};
