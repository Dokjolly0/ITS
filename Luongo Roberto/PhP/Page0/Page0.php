<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Cart</title>
</head>
<body>
    <h1>Carrello</h1>
    <?php
        //Dati fake da db
        $articolo1 = "Pasta";
        $quantita1 = 2;
        $prezzo1 = 1.5;

        $articolo2 = "Riso";
        $quantita2 = 1;
        $prezzo2 = 2.5;

        $articolo3 = "Patate";
        $quantita3 = 3;
        $prezzo3 = 0.5;

        $articolo4 = "Pomodori";
        $quantita4 = 5;
        $prezzo4 = 0.3;

        $articolo5 = "Cipolle";
        $quantita5 = 2;
        $prezzo5 = 0.2;

            //Crea tabella dove metti i dati
            echo "<table border='1'>";
            echo "<tr>";
            echo "<th style='background-color: lightblue'>Articolo</th>";
            echo "<th style='background-color: lightgreen'>Quantità</th>";
            echo "<th style='background-color: yellow'>Prezzo</th>";
            echo "</tr>";
            echo "<tr>";
            echo "<td style='background-color: lightblue'>$articolo1</td>";
            echo "<td style='background-color: lightgreen'>$quantita1</td>";
            echo "<td style='background-color: yellow'>$prezzo1</td>";
            echo "</tr>";
            echo "<tr>";
            echo "<td style='background-color: lightblue'>$articolo2</td>";
            echo "<td style='background-color: lightgreen'>$quantita2</td>";
            echo "<td style='background-color: yellow'>$prezzo2</td>";
            echo "</tr>";
            echo "<tr>";
            echo "<td style='background-color: lightblue'>$articolo3</td>";
            echo "<td style='background-color: lightgreen'>$quantita3</td>";
            echo "<td style='background-color: yellow'>$prezzo3</td>";
            echo "</tr>";
            echo "<tr>";
            echo "<td style='background-color: lightblue'>$articolo4</td>";
            echo "<td style='background-color: lightgreen'>$quantita4</td>";
            echo "<td style='background-color: yellow'>$prezzo4</td>";
            echo "</tr>";
            echo "<tr>";
            echo "<td style='background-color: lightblue'>$articolo5</td>";
            echo "<td style='background-color: lightgreen'>$quantita5</td>";
            echo "<td style='background-color: yellow'>$prezzo5</td>";
            echo "</tr>";
            echo "</table>";

        //Calcola totale
        $totale = $quantita1 * $prezzo1 + $quantita2 * $prezzo2 + $quantita3 * $prezzo3 + $quantita4 * $prezzo4 + $quantita5 * $prezzo5;
        echo "<h2>Totale senza iva: $totale €</h2>";
    ?>
</body>
</html>