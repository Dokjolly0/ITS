//npm install class-transformer //npm install class-validator
import {
  IsInt,
  IsMongoId,
  Min,
  IsString,
  IsDate,
  isString,
  IsUrl,
} from "class-validator";

export class User_register_dto {
  @IsString()
  firstName: string;

  @IsString()
  lastName: string;

  @IsUrl()
  @IsString()
  picture: string;
}
