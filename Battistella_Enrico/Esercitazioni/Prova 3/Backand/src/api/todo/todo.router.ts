import express from "express";
import { isAuthenticated } from "../../utils/auth/authenticated-middleware";
import {
  add_todo,
  show_todo,
  check_todo,
  uncheck_todo,
  assign_todo,
  get_by_title,
  get_by_id,
  delate_todo,
} from "./todo.controller";
import { validate } from "../../utils/validation-middleware";
import { Add_todo_dto } from "./todo.dto";
import { de } from "@faker-js/faker";

const router = express.Router();

router.use(isAuthenticated);
router.get("/", show_todo);
router.post("/", validate(Add_todo_dto), add_todo);
router.patch("/:id/check", check_todo);
router.patch("/:id/uncheck", uncheck_todo);
router.post("/:id/assign", assign_todo);
router.get("/title/:title", get_by_title);
router.get("/id/:id", get_by_id);
router.delete("/delete/:id", delate_todo);

export default router;
