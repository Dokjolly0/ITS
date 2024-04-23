import { genericHandler } from "./generics";
import { notFoundHandler } from "./not-found";

export const errorHandlers = [genericHandler, notFoundHandler];
