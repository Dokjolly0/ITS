import { UserModel, UserModelCredential } from "./user.model";

export class UserService {
  async register_user(firstName: string, lastName: string, picture: string) {
    const user = await UserModel.create({ firstName, lastName, picture });
    return user;
  }

  async credential_user(id_user: Object, username: string, password: string) {
    const user_credential = await UserModelCredential.create({
      id_user, // Aggiungi il campo 'id_user'
      username,
      password,
    });
    return user_credential;
  }
}

export default new UserService();
