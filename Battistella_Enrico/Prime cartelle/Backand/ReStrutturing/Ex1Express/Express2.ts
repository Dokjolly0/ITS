// Importa il modulo Express
import express from "express";
//const express = require("express");

// Crea un'applicazione Express
const app = express();

// Definisci una route per la richiesta GET alla radice dell'URL
app.get("/", (req, res, next) => {
  // Imposta lo stato della risposta a 200 (OK)
  res.status(200);
  // Invia "Hello world" come corpo della risposta
  res.send("Hello world");
});

// Fai in modo che l'applicazione Express inizi ad ascoltare le richieste HTTP sulla porta 3000
app.listen(3000, () => console.log("Server started on port 3000"));
