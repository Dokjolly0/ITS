import { User } from "../../../api/User/user.entity";

export interface UserIdentity {
  id: string;
  provider: "local";
  credentials: {
    username: string;
    hashedPassword: string;
  };
  user: User;
}
