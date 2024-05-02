import { NextFunction, Response } from "express";
import { TypedRequest } from "../../utils/typed-request";
import userService from "./user.service";

export const me = async (
  req: TypedRequest,
  res: Response,
  next: NextFunction
) => {
  res.json(req.user!);
};

export const show_all_users = async (
  req: TypedRequest,
  res: Response,
  next: NextFunction
) => {
  try {
    const user = req.user!;
    const users = await userService.show_all_users(user.id!);
    res.json(users);
  } catch (e) {
    next(e);
  }
};
