import { User } from "./user.entity";
import mongoose from "mongoose";

const user_schema = new mongoose.Schema<User>({
  firstName: { type: String, required: true },
  lastName: { type: String, required: true },
  picture: { type: String, required: true },
});

user_schema.virtual("fullName").get(function (this: User) {
  return `${this.firstName} ${this.lastName}`;
});

user_schema.set("toJSON", {
  virtuals: true,
  transform: (_, ret) => {
    ret.id = ret._id;
    delete ret._id;
    delete ret.__v;

    return ret;
  },
});

export const user_model = mongoose.model<User>("User", user_schema);
