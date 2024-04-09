<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Document</title>
    <style>
        .container{
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
        }
                table{
            border-collapse: collapse;
        }
        th, td{
            border: 3px solid black;
            padding: 10px;
        }
    </style>
</head>
<body>
    <?php
    // Connessione al server MySQL
    $link = mysqli_connect('localhost', 'alexviolatto', 'X3D6NqedZ97t', 'my_alexviolatto');
    // Verifica della connessione
    if (!$link) {
        die('Errore di connessione: ' . mysqli_connect_error());
    }
    
    // Seleziona il database
    $db_selected = mysqli_select_db($link, 'my_alexviolatto');
    if (!$db_selected) {
        die('Impossibile selezionare il database: ' . mysqli_error($link));
    }
    
    // Esegui la query
    $query = 'SELECT * FROM Articoli';
    $result = mysqli_query($link, $query);
    if (!$result) {
        die('Query fallita: ' . mysqli_error($link));
    }

    //Colore id
    $coloreId = 'rgba(255, 255, 0, 0.5)';
    //Colore nome
    $coloreNome = 'rgba(255, 165, 0, 0.5)';
    //Colore descrizione
    $coloreDescrizione = 'rgba(0, 0, 255, 0.5)';
    //Colore prezzo
    $colorePrezzo = 'rgba(0, 255, 0, 0.5)';
    //Colore giacenza
    $coloreGiacenza = 'rgba(139, 69, 19, 0.5)';

    $colori = array($coloreId, $coloreNome, $coloreDescrizione, $colorePrezzo, $coloreGiacenza);
    $counterColore = 0;

    // Mostra i risultati in una tabella
    echo '<div class=\'container\'>';
    echo '<table border=1>';
    // Intestazioni della tabella
    echo '<tr>';
    echo "<th style='background-color: $coloreId;'>Id</th>";
    echo "<th style='background-color: $coloreNome;'>Nome</th>";
    echo "<th style='background-color: $coloreDescrizione;'>Descrizione</th>";
    echo "<th style='background-color: $colorePrezzo;'>Prezzo</th>";
    echo "<th style='background-color: $coloreGiacenza;'>Giacenza</th>";
    echo '</tr>';
    while ($line = mysqli_fetch_array($result, MYSQLI_ASSOC)) {
        echo "\t<tr>\n";
        foreach ($line as $col_value) {
            echo "\t\t<td style=\"background-color: $colori[$counterColore]\">$col_value</td>\n";
            for($i = 0; $i < $line; $i++){
                $counterColore++;
                if($counterColore == 5){
                    $counterColore = 0;
                }
            }
        }
        echo "\t</tr>\n";
    }
    echo '</table>';
    echo '</div>';

    // Libera la memoria del risultato e chiudi la connessione al database
    mysqli_free_result($result);
    mysqli_close($link);
?>
</body>
</html>

