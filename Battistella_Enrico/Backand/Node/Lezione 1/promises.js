const { rejects } = require("assert");
const fs = require("fs/promises");
const { resolve } = require("path");

//#region V1 promise
// //Genera un file promise
// const filePromise = fs.readFile("./Test1.txt", { encoding: "utf-8" });
// //Se lo trova
// filePromise.then((content) => {
//   console.log(content);
// });
// //Se non lo trova
// filePromise.catch((err) => {
//   console.error(err);
// });
//#endregion

//#region V2 promise
// //Genera un file promise
// const filePromise = fs.readFile("./Test1.txt", { encoding: "utf-8" });
// //Se lo trova
// //thenPromise carrura il risultato di .then, se riesce o meno
// const thenPromise = filePromise.then((content) => {
//   console.log(content);
// });
// console.log(thenPromise);
// //Se non lo trova
// //catchPromise carrura il risultato di .catch, se riesce o meno
// const catchPromise = filePromise.catch((err) => {
//   console.error(err);
// });
// console.log(catchPromise);
//#endregion

//#region V3 promise
//Genera un file promise
const filePromise1 = fs.readFile("./Test1.txt", { encoding: "utf-8" });
filePromise1
  .then((content) => {
    return fs.readFile("./Test2.txt", { encoding: "utf-8" });
  })
  .then((result) => {
    console.log(result);
  })
  .catch((err) => {
    console.error(err);
  });
//#endregion

function promiseFs(filePath, option) {
  return new Promise((resolve, rejects) => {
    fs.readFile(filePath, option, (err, result) => {
      if (err) {
        rejects(err);
      } else {
        resolve(result);
      }
    });
  });
}
promiseFs("Test1.txt", { encoding: "utf-8" })
  .then((result) => {
    console.log(result);
  })
  .catch((err) => console.error(err));
