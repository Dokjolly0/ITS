import { Request, Response } from "express";
import { TypedRequest } from "../../utils/typed-request";
import userService from "./user.service";
import { tr } from "@faker-js/faker";

// Definizione del gestore di richieste 'me'
export const me = async (req: TypedRequest, res: Response) => {
  res.json(req.user!);
};

export const show_all_users = async (req: Request, res: Response) => {
  try {
    const users = await userService.show_all_users();
    res.status(200).json(users);
  } catch (error: any) {
    res.status(500).json({ error: error.message });
  }
};
