import {
  IsString,
  IsNotEmpty,
  IsBoolean,
  IsDate,
  IsBooleanString,
} from "class-validator";
import { Type } from "class-transformer";

export class crea_task_dto {
  @IsString()
  @IsNotEmpty()
  @Type(() => String)
  title: string;

  @IsDate()
  @Type(() => Date)
  dueDate: Date;
}
