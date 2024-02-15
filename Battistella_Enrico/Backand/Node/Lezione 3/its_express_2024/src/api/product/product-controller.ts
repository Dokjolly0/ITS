import { NextFunction, Request, Response } from "express";
import PRODUCTS from "../../../prodotti.json";
import { find as findProduct } from "./product-service";

export const list = async (
  req: Request,
  res: Response,
  _next: NextFunction
) => {
  const { search }: { search?: string } = req.query;

  const result = findProduct(search);

  res.json(result);
};

export const detail = (req: Request, res: Response, _next: NextFunction) => {
  const { id } = req.params;
  const item = PRODUCTS.find((item) => {
    return item.id === id;
  });
  if (!item) {
    res.status(404);
    res.send("Product not found");
  }
};
