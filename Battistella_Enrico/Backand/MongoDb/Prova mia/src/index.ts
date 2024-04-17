import bodyParser from "body-parser";
import express from "express";
import mongoose from "mongoose";
import morgan from "morgan";
import cors from "cors";

const app = express();
app.use(cors());
app.use(morgan("tiny"));
app.use(bodyParser.json());
// Configurazione delle route, middleware, ecc.

// Connessione al database MongoDB
const port = 3000;
mongoose.set("debug", true); // Abilita il logging delle query
mongoose
  .connect("mongodb://127.0.0.1:27017/todo")
  .then(() => {
    console.log("Connected to MongoDB");
    // Avvio del server dopo aver stabilito la connessione al database
    app.listen(port, () => {
      console.log(`Server listening on port ${port}`);
    });
  })
  .catch((err) => {
    console.error("Error connecting to MongoDB:", err);
  });

export default app;
