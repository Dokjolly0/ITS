import express from "express";
import cors from "cors";
import morgan from "morgan";
import bodyParser from "body-parser";

import apiRouter from "./src/api/routes";
import { errorHandlers } from "./src/errors";

const app = express();

app.use(cors());
app.use(morgan("tiny"));
app.use(bodyParser.json());
app.use(express.json());
app.use(express.urlencoded({ extended: true }));

app.use("/api", apiRouter);

app.use(errorHandlers);

export default app;
