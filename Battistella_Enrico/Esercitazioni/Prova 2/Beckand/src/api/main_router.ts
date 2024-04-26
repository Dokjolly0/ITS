// Node module
import { Router } from "express";

// Importa i router specifici
import todo_router from "./Todo/todo.router";
import user_router from "./User/user.router";

// Crea un'istanza del router
const mainRouter: Router = Router();

// Definisci le route secondarie
mainRouter.use("/todos", todo_router);
mainRouter.use("/users", user_router);

export default mainRouter;
