import "reflect-metadata";
import mongoose from "mongoose";

import app from "./app";

mongoose.set("debug", true);
mongoose
  .connect("mongodb://127.0.0.1:27017/todo-list")
  .then((_) => {
    console.log("Connesso al database");
    const PORT = 3000;
    app.listen(PORT, () => {
      console.log(`Server attivo alla porta ${PORT}`);
    });
  })
  .catch((err) => {
    console.error(err);
  });
