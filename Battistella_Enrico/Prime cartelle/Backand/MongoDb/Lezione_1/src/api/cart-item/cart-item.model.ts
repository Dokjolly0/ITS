import { CartItem } from "./cart-item.entity";
import mongoose from "mongoose";

const CartItemSchema = new mongoose.Schema<CartItem>({
  id: Number,
  quantity: Number,
  product: String, //Da cambiare type mongoose
});

CartItemSchema.set("toJSON", {
  virtuals: true,
  transform: (_, ret) => {
    delete ret._id;
    return ret;
  },
});

export const CartItemModel = mongoose.model<CartItem>(
  "Cart-item",
  CartItemSchema
);
