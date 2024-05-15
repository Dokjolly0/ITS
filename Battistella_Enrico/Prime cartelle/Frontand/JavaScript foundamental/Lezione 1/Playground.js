"use strict";
console.log(`Ciao`);
console.warn("Ciao");
console.error("Ciao");
console.info("Ciao");

let a;
//Dati primitivi
a = 0; //Number
a = " "; //String
a = true; //Bool
a = undefined; //Undefined
a = null; //Null
a = NaN; //Not a Number
//Dati strutturati
a = BigInt; //BigInt
a = []; //Array
a = {}; //Object

// const ora = new Date();
// ora.getUTCMonth();
// console.log(ora);

// switch (ora) {
//   case 0:
//     ora = "Gennaio";
//     break;
//   case 1:
//     "Febbraio";
//     break;
// }

//Cambiare versione node nvm
//nvm install [version]
//nvm use [version] 64

const cart = [
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
let lista = document.getElementById("lista");
for (let i = 0; i < cart.length; i++) {
  const prezzo = cart[i].netPrice;
  let sconto = cart[i].discount;
  const quantita = cart[i].quantity;
  const peso = cart[i].weight;
  const nome = cart[i].name;
  let costoSpedizione = 0;
  let iva = 0.22;

  const prezzoSoloSconto = prezzo * (sconto / 100);
  const prezzoScontato = quantita * (prezzo - prezzoSoloSconto);
  const prezzoScontatoConIva = prezzoScontato + prezzoScontato * iva;

  //   const scontoPercentuale = (100 - sconto) / 100;
  //   const prezzoScontato = prezzo * scontoPercentuale * quantita * iva;

  if (peso <= 2000) {
    costoSpedizione = 0;
  } else if (peso >= 2000 && peso < 5000) {
    costoSpedizione = 7;
  } else if (peso >= 5000 && peso < 10000) {
    costoSpedizione = 15;
  } else {
    costoSpedizione = 20;
  }
  const prezzoFinaleOggetto = prezzoScontatoConIva + costoSpedizione;
  //const totale = prezzoSconto * iva;
  // console.log(`${cart[i].name}: ${prezzoFinaleOggetto}`);
  let elementoLi = "<li>" + nome + ": " + prezzoFinaleOggetto + "</li>";
  let listaOggetti = document.getElementById("listaOggetti");
  listaOggetti.innerHTML += elementoLi;
}
console.log(prezzoFinale);

// const sconto = 5;
// const locale = 100;

// const prezzo = locale;
// const sconto_calcolato = prezzo * (sconto / 100);
// const prezzo_scontato = prezzo - sconto_calcolato;

// console.log("Prezzo originale:", prezzo);
// console.log("Sconto applicato:", sconto_calcolato);
// console.log("Prezzo scontato:", prezzo_scontato);
