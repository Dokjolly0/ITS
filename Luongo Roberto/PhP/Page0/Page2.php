<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Tabella con numeri da 1 a 100</title>
    <style>
        * {
            margin: 0;
            padding: 0;
        }
        table {
            border: 2px solid red; /* Imposta il bordo della tabella su rosso */
            border-collapse: collapse; /* Unisce i bordi delle celle */
            margin: 0 auto; /* Center the table */
        }
        th, td {
            border: 2px solid red; /* Imposta il bordo delle celle interne su rosso */
            padding: 8px; /* Aggiunge spazio interno alle celle */
            text-align: center;
            color: black;
            width: 15px;
        }
        body {
            background-color: white;
        }
        div {
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
        <table>
            <tbody>
                <?php
                //$voti = array(5, 6, 7, 8, 9, 10, 4, 3, 2, 1);
                for($i = 0; $i < 10; $i++) {
                    $voti[] = rand(1, 10); // Generate random grades for 10 students
                }
                $totaleVoti = array_sum($voti); // Calculate total grades
                $media = $totaleVoti / sizeof($voti); // Calculate average

                echo "<tr><th colspan='10'>La media generale della classe è di $media</th></tr>";

                foreach ($voti as $voto) {
                    $colore = sprintf('rgba(%d, %d, %d, 0.5)', rand(0, 255), rand(0, 255), rand(0, 255)); // Generate a random color with 50% opacity
                    echo "<tr>";
                    for ($i = 0; $i < 10; $i++) {
                        if ($i < $voto) {
                            echo "<td style='background-color: $colore'>x</td>"; // Apply the color with opacity to all 'x' for the student
                        } else {
                            echo "<td></td>"; // Print empty cells for remaining
                        }
                    }
                    echo "</tr>";
                }
                ?>
            </tbody>
        </table>
    </div>
</body>
</html>
