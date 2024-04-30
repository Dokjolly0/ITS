import mongoose from "mongoose";
import { User } from "./user.entity";

const user_schema = new mongoose.Schema<User>({
  firstName: String,
  lastName: String,
  picture: String,
});
user_schema.virtual("fullName").get(function () {
  return `${this.firstName} ${this.lastName}`;
});

user_schema.set("toJSON", {
  virtuals: true,
  transform: (_, ret) => {
    delete ret._id;
    delete ret.__v;
    return ret;
  },
});
user_schema.set("toObject", {
  virtuals: true,
  transform: (_, ret) => {
    delete ret._id;
    delete ret.__v;
    return ret;
  },
});

//Ordine nel db
user_schema.index({
  id: 1,
  firstName: 1,
  lastName: 1,
  fullName: 1,
  picture: 1,
});

export const UserModel = mongoose.model<User>("User", user_schema);
