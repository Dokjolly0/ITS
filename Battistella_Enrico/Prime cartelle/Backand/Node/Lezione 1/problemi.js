const fs = require("fs");

function getUser(id, callBack) {
  fs.readFile(`./${id}.txt`, { encoding: "utf-8" }, (err, user) => {
    if (err) {
      callBack(new Error("user not found"));
    } else {
      callBack(null, user);
    }
  });
}

getUser("a1", (id, user) => {});
