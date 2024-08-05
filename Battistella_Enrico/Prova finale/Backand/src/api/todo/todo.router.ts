import express from "express";
import { isAuthenticated } from "../../utils/auth/authenticated-middleware";
import {
  add,
  list,
  check,
  uncheck,
  assign,
  getByTitle,
  getById,
  delate,
  updateDate,
} from "./todo.controller";
import { validate } from "../../utils/validation-middleware";
import { addTodoDto, checkTodoDto } from "./todo.dto";

const router = express.Router();

router.use(isAuthenticated);
router.get("/", list);
router.post("/", validate(addTodoDto), add);
router.patch("/:id/check", validate(checkTodoDto, "params"), check);
router.patch("/:id/uncheck", validate(checkTodoDto, "params"), uncheck);
router.post("/:id/assign", assign);
/* Chiamate in più */
//router.post("/:id/assign", /*canAssing,*/validate(checkTodoDto), assign);
router.get("/title/:title", getByTitle);
router.get("/id/:id", getById);
router.delete("/delete/:id", delate);
router.patch("/:id/date", updateDate);

export default router;

//Controlla se l'utente ha accesso al todo
//Check e Uncheck possono essere fatti sia da chi li ha creati, sia da chi sono assegnati

// function canAssing(req: Request, res: Response, next: NextFunction) {
//   const todoId = req.params.id;
//   const userId = req.user?.id;
//   // fai il controllo
//   if (userCanAssign) {
//     next();
//   } else {
//     next(new NotFoundError());
//   }
// }
