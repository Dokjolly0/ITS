import { Request, Response, NextFunction } from "express";
import user_service from "./user.service";

export const registra_user = async (
  req: Request,
  res: Response,
  next: NextFunction
) => {
  const { firstName, lastName, picture, username, password } = req.body;
  try {
    const user = await user_service.register_user(
      firstName,
      lastName,
      picture,
      username,
      password
    );
    res.status(201).json(user);
  } catch (error) {
    res.status(500).json({
      errore: "InternalServerError",
      messaggio: "Il server ha riscontrato un errore interno.",
    });
    next(error);
    console.error(error);
  }
};
