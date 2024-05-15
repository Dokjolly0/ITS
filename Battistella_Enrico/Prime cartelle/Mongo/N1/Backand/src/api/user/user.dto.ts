import { IsEmail, IsString, IsUrl, Matches, MinLength } from "class-validator";

export class Add_user_dto {
  @IsString()
  firstName: string;

  @IsString()
  lastName: string;

  @IsUrl()
  picture: string;

  @IsEmail()
  username: string;

  @MinLength(8)
  password: string;
}

export class Login_user_dto {
  @IsEmail()
  username: string;

  @IsString()
  password: string;
}
