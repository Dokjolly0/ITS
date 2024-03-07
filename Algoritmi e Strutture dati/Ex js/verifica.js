function calcolaRepost(arr) {
  const numeroRepost = [];
  for (let i = 0; i < arr.length; i++) {
    if (arr[i] >= i + 1) numeroRepost.push(arr[i]);
    else break;
  }
  console.log(numeroRepost);
}
calcolaRepost([16, 12, 7, 5, 4, 3, 2, 1]);
calcolaRepost([54, 17, 14, 10, 9, 6, 6, 5, 4, 3]);

// Dato un albero con radice T, chiamiamo peso di un nodo v in T il numero dei suoi discendenti. Ad esempio, nell’albero seguente la radice ha peso 8. Proponi una procedura ricorsiva per calcolare, data la radice di un albero, il suo peso (a parole, in pseudocodice o in codice C#) e discutine informalmente la complessità.

//Dato un albero, calcola il peso totale dell'albero (albero vuoto pesa 0)
// const obj = {
//   a: {
//     valore: 5,
//     c: {
//       valore: 1,
//       e: {
//         valore: 0,
//         g: {
//           valore: 5,
//         },
//       },
//       f: {
//         h: {},
//       },
//     },
//   },
//   b: {
//     d: {},
//   },
// };

// const obj2 = {
//   a: {
//     valore: 8,
//     b: {
//       valore: 5,
//     },
//     c: {
//       valore: 5,
//     },
//   },
// };
