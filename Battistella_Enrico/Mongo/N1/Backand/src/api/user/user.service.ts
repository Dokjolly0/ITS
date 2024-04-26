import { UserIdentityModel } from "../../utils/auth/user.identity.model";
import { UserExistsError } from "../../errors/user_existing";
import { user_model } from "./user.model";
import { User } from "./user.entity";
import bcrypt from "bcrypt";

export class UserService {
  async add_user(
    user: User,
    credentials: { username: string; password: string }
  ): Promise<User> {
    // const user = await user_model.create({
    //   firstName,
    //   lastName,
    //   picture,
    //   username,
    //   password,
    // });
    // const newUser = await UserModel.create(user);
    // await UserIdentityModel.create({
    //   provider: "local",
    //   user: newUser.id,
    //   credentials: {
    //     username: credentials.username,
    //     hashedPassword,
    //   },
    // });
    // return user;
    const username_esistente = await UserIdentityModel.findOne({
      "credentials.username": credentials.username,
    });

    if (username_esistente) {
      throw new UserExistsError();
    }

    //bcript.hash(la tua password, 10)
    const password_criptata = await bcrypt.hash(credentials.password, 10);

    const nuovo_utente = await user_model.create(user);
    await UserIdentityModel.create({
      provider: "local",
      user: nuovo_utente.id,
      credentials: {
        username: credentials.username,
        password_criptata,
      },
    });

    return nuovo_utente;
  }
}

export default new UserService();
