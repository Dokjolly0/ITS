import { genericHandler } from "./generic";
import { notFoundHandler } from "./not_found";
import { validationErrorHandler } from "./validation";
import { UserExistsError } from "./user_exist";

export const errorHandlers = [
  notFoundHandler,
  validationErrorHandler,
  genericHandler,
];
