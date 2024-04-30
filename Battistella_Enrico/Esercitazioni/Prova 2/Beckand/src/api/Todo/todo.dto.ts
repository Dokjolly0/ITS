//npm install class-transformer //npm install class-validator
import { Type } from "class-transformer";
import {
  IsInt,
  IsMongoId,
  Min,
  IsString,
  IsDate,
  IsOptional,
} from "class-validator";
import mongoose from "mongoose";
import { isMongoId } from "validator";

export class Add_todo_dto {
  @IsString()
  title: string;

  @IsDate()
  dueDate: Date;

  @IsMongoId()
  @IsOptional()
  assignedTo: mongoose.Types.ObjectId;
}
