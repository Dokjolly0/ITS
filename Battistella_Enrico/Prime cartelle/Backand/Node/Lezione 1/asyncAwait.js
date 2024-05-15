const fs = require("fs/promises");

//#region V1
// async function mainFs() {
//   console.log("Request file");
//   const content1 = await fs.readFile("./Test1.txt", {
//     encoding: "utf-8",
//   });
//   console.log(content1);
//   const content2 = await fs.readFile("./Test22.txt", {
//     encoding: "utf-8",
//   });
//   console.log(content2);
// }
// mainFs().catch((err) => {
//   console.log("Errore nella lettura dei file");
// });
// console.log("Altre operazioni");
//#endregion

//#region V2
async function mainFs() {
  try {
    console.log("Request file");
    const content1 = await fs.readFile("./Test11.txt", {
      encoding: "utf-8",
    });
    console.log(content1);
    let content2;
    try {
      content2 = await fs.readFile("./Test2.txt", {
        encoding: "utf-8",
      });
    } catch (err) {
      content2 = "Default content";
    }
    console.log(content2);
  } catch (err) {
    console.log("Errore nella lettura del file");
    //Show error
    throw err;
  }
}
mainFs();
console.log("Altre operazioni");
//#endregion
