import todoService from "../Todo/todo.service";
import bcrypt from "bcrypt";
import UserService from "./user.service";
import { Request, Response, NextFunction } from "express";

export const register_user = async (
  req: Request,
  res: Response,
  next: NextFunction
) => {
  try {
    const { firstName, lastName, picture, username } = req.body;
    let { password } = req.body;
    const user = await UserService.register_user(firstName, lastName, picture);
    const id_user = user._id.toString(); // Converti l'ID in una stringa
    try {
      const provider = "Local";
      password = await bcrypt.hash(password, 10);
      await UserService.credential_user(id_user, provider, username, password);
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

export const logged_user = async (
  req: Request,
  res: Response,
  next: NextFunction
) => {
  const { username, password } = req.body;
  const logged_user = await UserService.login_user(username, password);
  if (logged_user) {
    res.status(200).json({ messaggio: "Utente loggato" });
  } else {
    res.status(500).json({ messaggio: "Va in mona" });
  }
};
