import express from "express";
import { validate } from "../../utils/validation-middleware";
import { Login_user_dto, Add_user_dto } from "./user.dto";
import { registra_user } from "./user.controller";

const router = express.Router();

router.post("/register", validate(Add_user_dto), registra_user);

export default router;
