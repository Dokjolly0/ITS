import express from "express";
import { validate } from "../../utils/validation-middleware";
import { crea_task_dto } from "./task.dto";
import {
  mostra_task,
  aggiungi_task,
  setta_completato,
  setta_non_completato,
} from "./task.controller";

const router = express.Router();

router.get("/", mostra_task);
router.post("/", validate(crea_task_dto), aggiungi_task);
router.patch("/:id/check", setta_completato);
router.patch("/:id/uncheck", setta_non_completato);

export default router;

//Routes:
// mostra_task: GET /api/todo
// aggiungi_task: POST /api/todo
// controlla_completamento: PATCH /api/todo/:id
// uncheck: PATCH /api/todo/:id/uncheck
