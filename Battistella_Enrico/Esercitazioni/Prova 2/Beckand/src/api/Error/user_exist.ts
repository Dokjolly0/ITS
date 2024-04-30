export class UserExistsError extends Error {
  // Il costruttore della classe UserExistsError
  constructor() {
    super(); // Chiama il costruttore della classe genitore (Error) senza specificare un messaggio
    this.name = "UserExists"; // Imposta il nome dell'errore come 'UserExists'
    this.message = "username already in use"; // Imposta il messaggio dell'errore come 'username already in use'
  }
}
