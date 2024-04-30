import mongoose from "mongoose";
import {
  user_entity as User,
  user_entityCredential as Credential,
} from "./user.entity";

const user_schema = new mongoose.Schema<User>(
  {
    id: { type: mongoose.Schema.Types.ObjectId },
    firstName: { type: String, required: true },
    lastName: { type: String, required: true },
    picture: { type: String, required: true },
  },
  {
    toJSON: {
      transform: function (doc, ret) {
        //Rimuovi il campo __v
        delete ret.__v;
        //Trasforma _id in id
        ret.id = ret._id;
        delete ret._id;
      },
    },
  }
);

const credentialSchema = {
  username: String,
  hash_password: String,
};

const user_credential_schema = new mongoose.Schema(
  {
    id: mongoose.Schema.ObjectId,
    provider: String,
    userId: { type: mongoose.Schema.Types.ObjectId, ref: "User" },
    credential: credentialSchema,
  },
  {
    toJSON: {
      transform: function (doc, ret) {
        //Rimuovi il campo __v
        delete ret.__v;
        //Trasforma _id in id
        ret.id = ret._id;
        delete ret._id;
      },
    },
  }
);

user_schema.virtual("fullName").get(function (this: User) {
  return `${this.firstName} ${this.lastName}`;
});

export const UserModel = mongoose.model<User>("User", user_schema);
export const UserModelCredential = mongoose.model<Credential>(
  "User_credential",
  user_credential_schema
);

/*
user_schema.set("toJSON", {
  virtuals: true,
  transform: function (doc, ret) {
    const orderedFields = {
      id: ret.id,
      firstName: ret.firstName,
      lastName: ret.lastName,
      fullName: ret.fullName,
      picture: ret.picture,
    };

    if (ret._id) {
      delete ret._id; // Elimina _id dall'oggetto JSON
      console.log("_id eliminato");
    }
    if (ret.__v !== undefined) {
      delete ret.__v; // Elimina __v dall'oggetto JSON solo se è presente
      console.log("__v eliminato");
    }

    console.log("User data JSON senza _id e __v:");

    return orderedFields;
  },
});

user_credential_schema.set("toJSON", {
  virtuals: true,
  transform: function (doc, ret) {
    const orderedFields = {
      id: ret.id,
      provider: String,
      id_user: ret.id_user,
      credential: {
        username: ret.username,
        hash_password: ret.password,
      },
    };

    if (ret._id) {
      delete ret._id; // Elimina _id dall'oggetto JSON
      console.log("_id eliminato");
    }
    if (ret.__v !== undefined) {
      delete ret.__v; // Elimina __v dall'oggetto JSON solo se è presente
      console.log("__v eliminato");
    }

    console.log("User credential JSON senza _id e __v:");

    return orderedFields;
  },
});
*/
