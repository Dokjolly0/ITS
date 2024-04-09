import { ValidationError as OriginalValidationError } from "class-validator";
import { NextFunction, Request, Response } from "express";
export class ValidationError extends Error {
  originalErrors: OriginalValidationError[];
  constructor(errors: OriginalValidationError[]) {
    super();
    this.name = "ValidationError";
    this.originalErrors = errors;
    this.message = this.originalErrors
      .map((err) => Object.values(err.constraints as any))
      .join("; ");
  }
}
export const validationErrorHandler = (
  err: Error,
  req: Request,
  res: Response,
  next: NextFunction
) => {
  if (err instanceof ValidationError) {
    res.status(400);
    res.json({
      name: err.name,
      message: err.message,
      details: err.originalErrors.map((e) => ({
        property: e.property,
        constraints: e.constraints,
        value: e.value,
      })),
    });
  } else {
    next(err);
  }
};
