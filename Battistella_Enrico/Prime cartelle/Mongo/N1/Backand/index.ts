import "reflect-metadata";
import mongoose from "mongoose";

import app from "./app";

mongoose.set("debug", true);
mongoose
  .connect("mongodb://127.0.0.1:27017/todo-list")
  .then((_) => {
    console.log("Connected to db");
    app.listen(3001, () => {
      console.log("Server listening on port 3000");
    });
  })
  .catch((err) => {
    console.error(err);
  });
