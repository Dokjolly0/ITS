function contaValori(valore) {
  let somma = 0;
  for (let i = 1; i <= valore; i++) somma += i;
  console.log(somma);
  return somma;
}
contaValori(100);

function moltiplica_add(n1, n2) {
  let risultato = 0;
  for (let i = 0; i < n2; i++) risultato += n1;
  console.log(risultato);
  return risultato;
}
moltiplica_add(10, 10);

function numeri_positivi(arr) {
  const new_arr = [];
  for (let i = 0; i < arr.length; i++) if (arr[i] > 0) new_arr.push(arr[i]);
  console.log(new_arr);
  return new_arr;
}
numeri_positivi([1, 2, 3, -1, -2, -3, 55]);

function coppie_uguali(str) {
  let numero_uguale = 0;
  for (let i = 0; i < str.length; i++)
    if (str[i] === str[i + 1] && str[i + 1] !== str[i + 2]) numero_uguale++;
  console.log(numero_uguale);
  return numero_uguale;
}
coppie_uguali("55ffa11b22");

function ricercaLineare(Array_ricerca, Numero_ricerca) {
  let Bool_ricerca = false;
  for (let i = 0; i < Array_ricerca.length; i++) {
    if (Array_ricerca[i] === Numero_ricerca) {
      console.log(`Numero ${Numero_ricerca} trovato`);
      Bool_ricerca = true;
      return Numero_ricerca;
    }
  }
  if (Bool_ricerca === false) console.log("Numero non trovato");
  return -1;
}
const Array_ricerca = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];
const Numero_ricerca = 7;
ricercaLineare(Array_ricerca, Numero_ricerca);

function ricercaMassimoIterativa(array) {
  //Assegna max al primo elemento
  let max = array[0];
  for (let i = 1; i < array.length; i++) {
    //Se la posizione successiva è maggiore di i allora quella posizione diventa il nuovo max
    if (array[i] > max) {
      max = array[i];
    }
  }
  //Ritorna il valore di max
  return max;
}

const arrayIterativo = [5, 8, 3, 10, 6, 2];
console.log(ricercaMassimoIterativa(arrayIterativo));

function ricercaBinaria(Array_ricerca, Numero_ricerca) {
  let inizio = 0;
  let fine = Array_ricerca.length - 1;

  while (inizio <= fine) {
    let medio = Math.floor((inizio + fine) / 2);
    if (Array_ricerca[medio] === numero) {
      console.log(`Numero ${numero} trovato`);
      return numero;
    } else if (Array_ricerca[medio] < numero) {
      inizio = medio + 1;
    } else {
      fine = medio - 1;
    }
  }
  console.log("Numero non trovato");
}
const arraybinario = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];
const numero = 8;
ricercaBinaria(arraybinario, numero);

function ricercaRicorsiva(array) {
  if (array.length === 1) return array[0];
  else {
    const newArray = ricercaRicorsiva(array.slice(1));
    return array[0] > newArray ? array[0] : newArray;
  }
}
const arrayRicorsivo = [1, 4, 2, 6, 8, 2, 6, 11, 4, 3, 2, 1];
console.log(ricercaRicorsiva(arrayRicorsivo));

//#region Algoritmi di ordinamento
function selectionSort(arr) {
  const newSelection = [];
  let currentSelection = [...arr];
  for (let i = 0; i < arr.length; i++) {
    //Trovi il minimo
    let minimo = Math.min(...currentSelection);
    //Trovi l'indice del minimo
    let indiceSelection = currentSelection.indexOf(minimo);
    //Elimini il minimo dal primo array
    currentSelection.splice(indiceSelection, 1);
    //Inserisci il minimo nel secondo array
    newSelection.push(minimo);
  }
  //Prende l'elemento piu basso dal primo array, lo elimina e lo mette nel secondo array
  console.log(newSelection, currentSelection);
}
const arrayOrder = [5, 8, 3, 10, 6, 2];
selectionSort(arrayOrder);

function insertionSort(arr) {
  for (let i = 0; i < arr.length; i++) {
    if (arr[i + 1] > arr[i]) {
    }
  }
}
//#endregion

// function percentuali(arr) {
//   const n = 10;
//   const lunghezzaArr = arr.length;
//   let counter = 0,
//     media = 0;
//   for (let i = 0; i < arr.length; i++) {
//     if (arr[i] < counter) counter++;
//     media =
//   }
// }
