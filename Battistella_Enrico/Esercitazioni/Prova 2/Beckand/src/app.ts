import express from "express";
import cors from "cors";
import morgan from "morgan";
import bodyParser from "body-parser";
import fs from "fs";
import path from "path";
import "./utils/auth/auth-handlers";

import mainRouter from "./api/main_router";
import { errorHandlers } from "./api/Error/error";

const app = express();

app.use(cors());
app.use(morgan("tiny"));
app.use(bodyParser.json());
app.use(express.json());
app.use(express.urlencoded({ extended: true }));

//Legge i file html
const filePathPrincipal = path.join(
  __dirname,
  ".",
  "html_page",
  "principal.html"
);

const filePath = path.join(__dirname, ".", "html_page", "not_found.html");
const dataNotFound = fs.readFileSync(filePath, "utf8");

// Route per gestire le richieste API
app.use("/api", mainRouter);

// Route per gestire gli altri URL
app.use((req, res, next) => {
  res.status(404).send(dataNotFound); // Restituisci un messaggio di errore 404 per altri URL
});

app.use(errorHandlers);
export default app;
