import express from "express";
import { TodoDto } from "./todo.dto";
import todoService from "./todo.service";

const router = express.Router();

router.get("/list", async (req, res, next) => {
  try {
    const todos = await todoService.getAll();
    res.json(todos);
  } catch (error) {
    next(error);
  }
});

router.post("/create", checkSchema(TodoDto), async (req, res, next) => {
  try {
    const errors = validationResult(req);
    if (!errors.isEmpty()) {
      return res.status(400).json({ errors: errors.array() });
    }
    const todo = req.body as TodoDto;
    const newTodo = await todoService.create(todo);
    res.status(201).json(newTodo);
  } catch (error) {
    next(error);
  }
});

router.put("/check/:id", async (req, res, next) => {
  try {
    const id = req.params.id;
    const todo = await todoService.check(id);
    if (!todo) {
      return res.status(404).json({ message: "Todo not found" });
    }
    res.json(todo);
  } catch (error) {
    next(error);
  }
});

router.put("/uncheck/:id", async (req, res, next) => {
  try {
    const id = req.params.id;
    const todo = await todoService.unceck(id);
    if (!todo) {
      return res.status(404).json({ message: "Todo not found" });
    }
    res.json(todo);
  } catch (error) {
    next(error);
  }
});
