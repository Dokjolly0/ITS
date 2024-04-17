// Richiedi il modulo http incorporato in Node.js
const http = require("http");
//npm i --save-dev @types/node

// Crea un server HTTP che risponde alle richieste
// La funzione di callback viene eseguita ogni volta che viene ricevuta una richiesta
const server = http.createServer((req, res) => {
  // Imposta l'intestazione della risposta con il codice di stato 200 (OK)
  // e specifica il tipo di contenuto come testo semplice
  res.writeHead(200, { "Content-Type": "text/plain" });

  // Invia "Hello world" come corpo della risposta
  res.end("Hello world");
});

// Fai in modo che il server inizi ad ascoltare le richieste HTTP sulla porta 3000
server.listen(3000);
// Scrive Hello world appena apri il browser e vai su localhost:3000 mentre il server è attivo
