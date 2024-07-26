import express, { Request, Response, NextFunction } from "express";
import { isAuthenticated } from "../../utils/auth/authenticated-middleware";
import {
  add,
  list,
  check,
  uncheck,
  assign,
  get_by_title,
  get_by_id,
  delate_todo,
  update_date,
} from "./todo.controller";
import { validate } from "../../utils/validation-middleware";
import { Add_todo_dto, Check_todo_dto } from "./todo.dto";
import { NotFoundError } from "../../errors/not-found";

const router = express.Router();

router.use(isAuthenticated);
router.get("/", list);
router.post("/", validate(Add_todo_dto), add);
router.patch("/:id/check", validate(Check_todo_dto, "params"), check);
router.patch("/:id/uncheck", validate(Check_todo_dto, "params"), uncheck);
router.post("/:id/assign", /*canAssing,*/ assign);
router.get("/title/:title", get_by_title);
router.get("/id/:id", get_by_id);
router.delete("/delete/:id", delate_todo);
router.patch("/:id/date", update_date);

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
