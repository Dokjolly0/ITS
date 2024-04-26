import { user_entity as User } from "../User/user.entity";

export interface task_entity {
  id?: string;
  title: string;
  dueDate: Date;
  completed: Boolean;
  expired?: Boolean;
  createdBy?: User;
  assignedTo?: User;
}
