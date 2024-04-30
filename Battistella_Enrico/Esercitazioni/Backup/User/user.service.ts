import mongoose from "mongoose";
import bcrypt from "bcrypt";
import { UserModel, UserModelCredential } from "./user.model";

export class UserService {
  async register_user(firstName: string, lastName: string, picture: string) {
    const user = await UserModel.create({ firstName, lastName, picture });
    console.log(user.toJSON());
    return user;
  }

  async credential_user(
    userId: Object,
    provider: string,
    username: string,
    password: string
  ) {
    const user_credential = await UserModelCredential.create({
      provider,
      userId, // Cambia id_user in userId
      credential: {
        username,
        hash_password: password, // Cambia password in hash_password
      },
    });
    console.log(user_credential.toJSON());
    return user_credential;
  }

  async login_user(username: string, password: string) {
    const user: any = await UserModel.findOne({ username });
    console.log(user);
    const username_db = user.credential.username;
    const hash_password_db = user.credential.password;
    if (user.username) {
      const hash_password = await bcrypt.hash(password, 10);
      if (hash_password === hash_password_db && username === username_db) {
        return true;
      }
    }
  }
}

export default new UserService();
