import express from "express";
import { register_user } from "./user.controller";

const router = express.Router();

router.post("/register", register_user);

export default router;
