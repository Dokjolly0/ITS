import todoService from "../Todo/todo.service";
import UserService from "./user.service";
import { Request, Response, NextFunction } from "express";

export const register_user = async (
  req: Request,
  res: Response,
  next: NextFunction
) => {
  try {
    const { firstName, lastName, picture, username, password } = req.body;
    const user = await UserService.register_user(firstName, lastName, picture);
    const id_user = user._id.toString(); // Converti l'ID in una stringa
    try {
      const user_credential = await UserService.credential_user(
        id_user,
        username,
        password
      );
      console.log(user_credential);
    } catch (credentialError) {
      console.error(
        "Errore durante la creazione delle credenziali:",
        credentialError
      );
    }
    res.status(201).json(user);
  } catch (err) {
    console.error(err);
    res.status(500).json({
      errore: "InternalServerError",
      messaggio: "Il server ha riscontrato un errore interno.",
    });
  }
};
