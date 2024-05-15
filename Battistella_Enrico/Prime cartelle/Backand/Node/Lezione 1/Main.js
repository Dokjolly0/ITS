const fs = require("fs");

console.log("requesting test1");
const content1 = fs.readFileSync("./Test1.txt", {
  encoding: "utf-8",
});
console.log(content1);

console.log("requesting Test2");
fs.readFile(
  "./Test2.txt",
  {
    encoding: "utf-8",
  },
  (err, content2) => {
    console.log(err, content2);
    if (err) {
      console.error(err);
    } else {
      console.log(content2);
    }
  }
);
console.log(Ciao);
