import express from "express";
//npm install -D @types/express in cmd
import cors from "cors";
//npm install -D @types/cors in cmd
import morgan from "morgan";
//npm install -D @types/morgan in cmd

//{ fakerIT as faker } fakerIT Questo è il nome originale, lo cambi in faker
import { de, fakerIT as faker } from "@faker-js/faker";
//npm install --save-dev @faker-js/faker in cmd
import { writeFileSync } from "fs";

//Questo per tutti e 3 i primi
//npm i --save-dev @types/express @types/morgan @types/cors

//{
//     id: string,
//     name: string, commerce.mongodbObjectId
//     description: string, commerce.productName
//     netPrice: number, commerce.
//     Weight: number,
//     discount: number
// }

function randomNumber() {
  //   return {
  //     id: faker.database.mongodbObjectId(),
  //     name: faker.commerce.productName(),
  //     description: faker.commerce.productDescription(),
  //     netPrice: faker.commerce.price({ min: 1, max: 10000 }),
  //     weight: faker.number.int({ min: 50, max: 2000 }),
  //     discount: faker.number.float({ min: 0, max: 1, fractionDigits: 2 }),
  //     //fractionDigits sono le cifre dopo lo 0
  //   };

  const id = faker.database.mongodbObjectId();
  const name = faker.commerce.productName();
  const description = faker.commerce.productDescription();
  const netPrice = faker.commerce.price({ min: 1, max: 10000 });
  const weight = faker.number.int({ min: 50, max: 2000 });
  const discount = faker.number.float({ min: 0, max: 1, fractionDigits: 2 });

  return { id, name, description, netPrice, weight, discount };
}
const tmp = randomNumber();
console.log(tmp);

function generaProdotti(n: number) {
  const prodotti: any[] = [];
  for (let i = 0; i < n; i++) {
    prodotti.push(randomNumber());
  }
  writeFileSync("./src/prodotti.json", JSON.stringify(prodotti), {
    encoding: "utf-8",
  });
}
generaProdotti(1);
