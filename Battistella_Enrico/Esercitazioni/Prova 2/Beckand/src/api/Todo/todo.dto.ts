//npm install class-transformer //npm install class-validator
import { Type } from "class-transformer";
import { IsInt, IsMongoId, Min, IsString, IsDate } from "class-validator";
import { isMongoId } from "validator";
import { user_entity as User } from "../User/user.entity";

export class Add_todo_dto {
  @IsString()
  title: string;

  @IsDate()
  dueDate: Date;
}
