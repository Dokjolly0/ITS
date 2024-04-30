// Import delle dipendenze necessarie da Express e dalle librerie di validazione
import { NextFunction, Response } from "express";
import { plainToClass } from "class-transformer";
import { validate as classValidate } from "class-validator";
import { ValidationError } from "../api/Error/validation";
import { TypedRequest } from "./typed-request";

// Definizione della funzione validateFn con overloading per gestire body e query separatamente
function validateFn<T extends object>(
  type: new () => T
): (
  req: TypedRequest<T, any>,
  res: Response,
  next: NextFunction
) => Promise<void>;
function validateFn<T extends object>(
  type: new () => T,
  origin: "body"
): (
  req: TypedRequest<T, any>,
  res: Response,
  next: NextFunction
) => Promise<void>;
function validateFn<T extends object>(
  type: new () => T,
  origin: "query"
): (
  req: TypedRequest<any, T>,
  res: Response,
  next: NextFunction
) => Promise<void>;
function validateFn<T extends object>(
  type: new () => T,
  origin: "body" | "query" = "body"
) {
  // Ritorna un middleware di Express
  return async (
    req: TypedRequest<any, any>,
    res: Response,
    next: NextFunction
  ) => {
    // Trasforma i dati della richiesta nel tipo specificato
    const data = plainToClass(type, req[origin]);
    // Valida i dati trasformati rispetto alle regole definite nella classe
    const errors = await classValidate(data);

    // Se ci sono errori di validazione, crea un'istanza di ValidationError
    // contenente gli errori e passa il controllo a Express tramite next
    if (errors.length) {
      next(new ValidationError(errors));
    } else {
      // Se non ci sono errori, sostituisci i dati della richiesta con quelli validati
      req[origin] = data;
      // Passa il controllo a Express
      next();
    }
  };
}

// Export della funzione validate, che è un'istanza di validateFn
export const validate = validateFn;
