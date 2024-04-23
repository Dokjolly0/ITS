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
  @Matches(new RegExp("((?=.*d)|(?=.*W+))(?![.\n])(?=.*[A-Z])(?=.*[a-z]).*$"), {
    message:
      "password must contain at least 1 uppercase letter, 1 lowercase letter, 1 number or special character",
  })
  password: string;
}

export class Login_user_dto {
  @IsEmail()
  username: string;

  @IsString()
  password: string;
}
