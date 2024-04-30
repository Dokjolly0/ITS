import express from "express";
import { register_user, logged_user } from "./user.controller";

const router = express.Router();

router.post("/register", register_user);
router.post("/login", logged_user);

export default router;
