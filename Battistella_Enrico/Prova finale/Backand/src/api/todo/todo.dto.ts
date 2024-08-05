//npm install class-transformer //npm install class-validator
import { IsMongoId, IsString, IsOptional, IsDateString } from "class-validator";
import mongoose from "mongoose";

export class addTodoDto {
  @IsString()
  title: string;

  @IsDateString()
  @IsOptional()
  dueDate?: Date;

  @IsMongoId()
  @IsOptional()
  assignedTo: mongoose.Types.ObjectId;

  // @IsMongoId()
  // createdBy: mongoose.Types.ObjectId;
}

export class checkTodoDto {
  @IsMongoId()
  id: string;
}
