const path = require("path");

// Percorso di partenza
const percorsoPartenza =
  "C:\\Users\\violatto_a\\Desktop\\ITS\\Battistella_Enrico\\Esercitazioni\\Prova 2\\Beckand\\src\\api";

// Percorso di destinazione
const percorsoDestinazione =
  "C:\\Users\\violatto_a\\Desktop\\ITS\\Battistella_Enrico\\Esercitazioni\\Prova 2\\Beckand\\src\\html_page\\principal.html";

// Ottieni il percorso relativo dalla partenza alla destinazione
const percorsoRelativo = path.relative(percorsoPartenza, percorsoDestinazione);

console.log(percorsoRelativo);
