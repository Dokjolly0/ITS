import express from "express";
import { isAuthenticated } from "../../utils/auth/authenticated-middleware";
import { me } from "./user.controller";
import { show_all_users } from "./user.controller";

const router = express.Router();

router.get("/me", isAuthenticated, me);
router.get("/users", isAuthenticated, show_all_users);

export default router;
