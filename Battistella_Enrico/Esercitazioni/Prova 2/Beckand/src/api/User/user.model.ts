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
    const id = ret._id ? ret._id.toString() : null;

    //console.log("Valore di _id:", ret._id);
    //console.log("Valore di __v:", ret.__v);

    const orderedFields = {
      id: ret.id, // Utilizza l'ID estratto
      firstName: ret.firstName,
      lastName: ret.lastName,
      fullName: ret.fullName,
      picture: ret.picture,
    };

    if (ret._id) {
      delete ret._id; // Elimina _id dall'oggetto JSON
      //console.log("_id eliminato");
    }
    if (ret.__v !== undefined) {
      delete ret.__v; // Elimina __v dall'oggetto JSON solo se è presente
      //console.log("__v eliminato");
    }

    //console.log("Oggetto JSON senza _id e __v:", orderedFields);

    return orderedFields;
  },
});

export const UserModel = mongoose.model<User>("User", user_schema);
