import { fakerIT as faker } from "@faker-js/faker";
import { writeFileSync } from "fs";

function randomNumber() {
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
  writeFileSync("./prodotti.json", JSON.stringify(prodotti, null, 2), {
    encoding: "utf-8",
  });
}
generaProdotti(30);
