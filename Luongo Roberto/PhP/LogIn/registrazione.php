<!DOCTYPE html>
<html lang="it">
<head>
<meta charset="UTF-8">
<meta name="viewport" content="width=device-width, initial-scale=1.0">
<title>Registrazione</title>
<style>
.container{
  display: flex;
  align-items: center;
  justify-content: center;
  height: 100vh;
  border: 1px solid red;
}
input{
  margin: 10px;
  padding: 10px;
  border: 1px solid #000;
  border-radius: 5px;
}
h2{
	text-align: center;
}
p{
    position: absolute;
    top: 10px;
    left: 10px;
}
</style>
</head>
<body>
<script>
window.addEventListener('load', function(){
    const bottone = document.getElementById('bottone');
    const email = document.getElementById('email');
    const password1 = document.getElementById('password');
    const password2 = document.getElementById('confirm_password');

    bottone.addEventListener('click', function(){
    if(password1.value !== password2.value) {
        alert('Le password non corrispondono');
    }
    if(password1.value.length < 8) {
        alert('La password deve essere di almeno 8 caratteri');
    }
    if(!document.getElementById('accept_terms').checked) {
        alert('Devi accettare i termini e le condizioni');
    }
    if(email.value === '' || password1.value === '' || password2.value === '') {
        alert('Compila tutti i campi');
    }
    })
})
</script>
<h2>Registrazione</h2>
<div class="container">
<form action="" method="post">
  <div>
    <label for="email">Mail:</label><br>
    <input type="email" id="email" name="email" required><br>
  </div>
  <div>
    <label for="password">Password:</label><br>
    <input type="password" id="password" name="password" required><br>
  </div>
  <div>
    <label for="confirm_password">Verifica password:</label><br>
    <input type="password" id="confirm_password" name="confirm_password" required><br>
  </div>
  <div>
    <input type="checkbox" id="accept_terms" name="accept_terms" required>
    <label for="accept_terms">Accetto i termini e le condizioni</label>
  </div>
  <br>
  <button id="bottone">Registrati</button>
</form>
</div>
<?php
session_start();

// Connessione db
$stringConn = mysqli_connect("localhost", "alexviolatto", "X3D6NqedZ97t", "my_alexviolatto");
if (!$stringConn){
    die("Connessione fallita: " . mysqli_connect_error());
}

// Controlla se i campi email e password sono stati inviati tramite POST
if(isset($_POST['email']) && isset($_POST['password'])) {
    $email = $_POST['email'];
    $password = $_POST['password'];

    // Verifica che i campi non siano vuoti
    if(!empty($email) && !empty($password)) {
        $strSQL = "SELECT * FROM Login WHERE Email='$email'";
        $query = mysqli_query($stringConn, $strSQL);
        if (!$query) {
            die("Query fallita: " . mysqli_error($stringConn));
        }

        $numerorecord = mysqli_num_rows($query);
        if ($numerorecord == 0) {
            $insertString = "INSERT INTO Login (Email, Password) VALUES ('$email', '$password')";
            $insertQuery = mysqli_query($stringConn, $insertString);
            if (!$insertQuery) {
                die("Inserimento fallito: " . mysqli_error($stringConn));
            }
            $_SESSION['registrazione_completata'] = true;
            echo "<br><p>Registrazione completata</p>";
        } else {
            echo "<br><p>Utente già registrato</p>";
        }
    } else {
        echo "<br><p>I campi email e password non possono essere vuoti.</p>";
    }
}

// Verifica se la registrazione è stata completata nella sessione
if(isset($_SESSION['registrazione_completata']) && $_SESSION['registrazione_completata'] === true) {
    unset($_SESSION['registrazione_completata']); // Cancella la variabile di sessione per evitare di mostrare il messaggio più volte
}

mysqli_close($stringConn);
?>

</body>
</html>
