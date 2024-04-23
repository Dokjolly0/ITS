import { Router } from "express";
import taskRouter from "./todo/task.router";
import userRouter from "./user/user.router";

const router = Router();

router.use("/todos", taskRouter);
router.use("/users", userRouter);

export default router;
