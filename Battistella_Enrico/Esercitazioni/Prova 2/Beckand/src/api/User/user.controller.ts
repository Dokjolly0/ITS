import { Request, Response } from "express";
import { TypedRequest } from "../../utils/typed-request";

// Definizione del gestore di richieste 'me'
export const me = async (req: TypedRequest, res: Response) => {
  res.json(req.user!);
};
