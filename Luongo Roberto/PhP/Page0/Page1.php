<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Tabella con numeri da 1 a 100</title>
    <style>
    	*{
        	margin: 0;
            padding: 0;
        }
        table {
            border: 2px solid red; /* Imposta il bordo della tabella su rosso */
            border-collapse: collapse; /* Unisce i bordi delle celle */
        }
        th, td {
            border: 2px solid red; /* Imposta il bordo delle celle interne su rosso */
            padding: 8px; /* Aggiunge spazio interno alle celle */
            text-align: center;
            color: white;
        }
        body{
            background-color: black;
        }
        div{
        	display: flex;
            align-items: center;
            justify-content: center;
            width: 100%;
            height: 100vh;
        }
    </style>
</head>
<body>
<div>
	    <table border="1">
        <tbody>
            <?php
            // Stampa le righe con i numeri da 1 a 100
            $contatore = 1;
            for ($riga = 1; $riga <= 10; $riga++) {
                echo "<tr>";
                for ($colonna = 1; $colonna <= 10; $colonna++) {
                    echo "<td>$contatore</td>";
                    $contatore++;
                }
                echo "</tr>";
            }
            ?>
        </tbody>
    </table>
</div>
</body>
</html>
