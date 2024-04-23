import { user_model } from "./user.model";

export class UserService {
  async register_user(firstName, lastName, picture, username, password) {
    const user = await user_model.create({
      firstName,
      lastName,
      picture,
      username,
      password,
    });
    return user;
  }
}

export default new UserService();
