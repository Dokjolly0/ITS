import express from "express";
import { isAuthenticated } from "../../utils/authenticated";
import {
  add_todo,
  show_todo,
  check_todo,
  uncheck_todo,
} from "./todo.controller";

const router = express.Router();

router.use(isAuthenticated);
router.get("/", show_todo);
router.post("/", add_todo);
router.patch("/:id/check", check_todo);
router.patch("/:id/uncheck", uncheck_todo);

export default router;
