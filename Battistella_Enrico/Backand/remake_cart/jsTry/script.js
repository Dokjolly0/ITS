//#region Cart
const cart = [
  {
    name: "ssd",
    netPrice: 95,
    weight: 100,
    discount: 5,
    quantity: 2,
    country: "italy",
  },
  {
    name: "motherboard",
    netPrice: 270,
    weight: 900,
    discount: 0,
    quantity: 1,
    country: "russia",
  },
  {
    name: "ram",
    netPrice: 120,
    weight: 60,
    discount: 10,
    quantity: 2,
    country: "italy",
  },
  {
    name: "processor",
    netPrice: 400,
    weight: 130,
    discount: 0,
    quantity: 1,
    country: "new zeland",
  },
  {
    name: "power supply",
    netPrice: 130,
    weight: 1400,
    discount: 15,
    quantity: 1,
    country: "italy",
  },
  {
    name: "cpu cooler",
    netPrice: 170,
    weight: 1000,
    discount: 23,
    quantity: 1,
    country: "spain",
  },
  {
    name: "gpu",
    netPrice: 1600,
    weight: 2500,
    discount: 0,
    quantity: 1,
    country: "france",
  },
  {
    name: "case",
    netPrice: 130,
    weight: 3500,
    discount: 30,
    quantity: 1,
    country: "italy",
  },
];
//#endregion

let nomi = [],
  prezzi = [],
  pesi = [],
  sconti = [],
  quantita = [],
  nazioni = [];
let totaleOggetti = 0;
let totaleSpedizioni = 0;
let totaleIVA = 0;
let costoSpedizioni = [];
let costoIVA = [];

for (let i = 0; i < cart.length; i++) {
  nomi[i] = cart[i].name;
  prezzi[i] = cart[i].netPrice;
  pesi[i] = cart[i].weight;
  sconti[i] = cart[i].discount;
  quantita[i] = cart[i].quantity;
  nazioni[i] = cart[i].country;

  //Spedizioni
  if (pesi[i] <= 2000) costoSpedizioni[i] = 0;
  if (pesi[i] >= 2000 && pesi[i] <= 5000) costoSpedizioni[i] = 7;
  if (pesi[i] >= 5000 && pesi[i] <= 10000) costoSpedizioni[i] = 15;
  if (pesi[i] >= 10000) costoSpedizioni[i] = 20;
  //IVA
  if (nazioni[i] === "italy") costoIVA[i] = prezzi[i] * quantita[i] * 0.22;
  if (nazioni[i] !== "italy") costoIVA[i] = 0;
  //Calcoli
  totaleOggetti += prezzi[i] * quantita[i];
  totaleSpedizioni += costoSpedizioni[i];
  totaleIVA += costoIVA[i];
  console.log(`Oggetto ${i + 1}: `);
  console.log(`Nome: ${nomi[i]}`);
  console.log(`prezzo: ${prezzi[i]}`);
  console.log(`peso: ${pesi[i]}`);
  console.log(`sconto: ${sconti[i]}`);
  console.log(`quantita: ${quantita[i]}`);
  console.log(`nazione: ${nazioni[i]}`);
  console.log(" ");
}
console.log(`Costo totale oggetti: ${totaleOggetti}`);
console.log(`Costo totale spedizioni: ${totaleSpedizioni}`);
console.log(`Costo totale IVA: ${totaleIVA.toFixed(2)}`);
console.log(
  `Totale complessivo: ${totaleOggetti + totaleSpedizioni + totaleIVA}`
);
