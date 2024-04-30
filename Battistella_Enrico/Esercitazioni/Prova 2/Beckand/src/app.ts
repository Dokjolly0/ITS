import express from "express";
import cors from "cors";
import morgan from "morgan";
import bodyParser from "body-parser";
import fs from "fs";
import path from "path";
import "./utils/auth/auth-handlers";

import mainRouter from "./api/main_router";

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
const dataPrincipal = fs.readFileSync(filePathPrincipal, "utf8");

const filePath = path.join(__dirname, ".", "html_page", "not_found.html");
const dataNotFound = fs.readFileSync(filePath, "utf8");

// Route principale per restituire il file HTML solo quando l'URL è '/'
app.get("/", (req, res) => {
  res.setHeader("Content-Type", "text/html");
  res.status(300).send(dataPrincipal); // Restituisci il file HTML solo per '/'
});

// Route per gestire le richieste API
app.use("/api", mainRouter);

// Route per gestire gli altri URL
app.use((req, res) => {
  res.status(404).send(dataNotFound); // Restituisci un messaggio di errore 404 per altri URL
});

export default app;
