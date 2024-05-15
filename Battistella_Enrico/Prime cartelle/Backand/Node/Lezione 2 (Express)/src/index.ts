const http = require("http");
const express = require("express");
const cors = require("cors");
const morgan = require("morgan");
const app = express();
// http
//   .createServer((require, response) => {
//     response.writeHead(200, { "Content-Type": "text/plain" });
//     response.end("Hello world");
//   })
//   .listen(3000);
interface CART{
  name: string;
  netPrice: number;
  weight: number;
  discount: number;
  quantity: number;
}
const cart: CART[] = [
  {
    name: "ssd",
    netPrice: 95,
    weight: 100,
    discount: 5,
    quantity: 2,
  },
  {
    name: "motherboard",
    netPrice: 270,
    weight: 900,
    discount: 0,
    quantity: 1,
  },
  {
    name: "ram",
    netPrice: 120,
    weight: 60,
    discount: 10,
    quantity: 2,
  },
  {
    name: "processor",
    netPrice: 400,
    weight: 130,
    discount: 0,
    quantity: 1,
  },
  {
    name: "power supply",
    netPrice: 130,
    weight: 1400,
    discount: 15,
    quantity: 1,
  },
  {
    name: "cpu cooler",
    netPrice: 170,
    weight: 1000,
    discount: 23,
    quantity: 1,
  },
  {
    name: "gpu",
    netPrice: 1600,
    weight: 2500,
    discount: 0,
    quantity: 1,
  },
  {
    name: "case",
    netPrice: 130,
    weight: 3500,
    discount: 30,
    quantity: 1,
  },
];
app.use(cors());
app.use(morgan("tiny"));
app.get("/", (req, res, next) => {
  res.setHeader("Content-Type", "text/plain");
  res.status(200);
  res.send("Hello world");
});
app.get("/Ciao", (req, res, next) => {
  res.setHeader("Content-Type", "text/plain");
  res.status(200);
  res.send("Hello world");
});
// /cart
app.get("/cart", (req, res, next) => {
  res.json(cart);
});
const server = http.createServer(app);
server.listen(3000);

const a:number = 1;