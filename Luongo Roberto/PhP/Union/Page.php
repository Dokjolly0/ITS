<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Document</title>
    <style>
        .center {
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
        }

        .formCenter {
            display: flex;
            justify-content: center;
        }

        table {
            border-collapse: collapse;
        }

        th, td {
            border: 3px solid orange;
            padding: 10px;
            background: rgba(0, 0, 0, 0.1);
        }
    </style>
</head>
<body>
  <div class="formCenter">
<form name="FormRicerca" action="" method="post">
    <input type="number" name="ricercaMax" id="ricercaMax" placeholder="Prezzo massimo" min=0/>
    <input type="number" name="ricercaMin" id="ricercaMin" placeholder="Prezzo minimo" min=0>
    <input type="submit" value="Cerca"/>
</form>
</div>
<!-- Show article -->
<div class="center">
    <?php
    if (isset($_POST['ricercaMax'])) {
        $conn = mysqli_connect("localhost", "alexviolatto", "X3D6NqedZ97t", "my_alexviolatto");
        if (!$conn) {
            die('Errore di connessione: ' . mysqli_connect_error());
        }
        $prezzoMax = $_POST['ricercaMax'];
        $prezzoMin = $_POST['ricercaMin'];

        $sql = "SELECT * FROM Articoli WHERE Prezzo < $prezzoMin AND Prezzo > $prezzoMax";
        $result = mysqli_query($conn, $sql);
        if (mysqli_num_rows($result) > 0) {
            echo "<table>";
            echo "<tr>";
            echo "<th>Id</th>";
            echo "<th>Nome</th>";
            echo "<th>Prezzo</th>";
            echo "<th>Descrizione</th>";
            echo "<th>Giacenza</th>";
            echo "</tr>";
            while ($row = mysqli_fetch_assoc($result)) {
                //Tabella
                echo "<tr>";
                echo "<td>" . $row["ArticoloId"] . "</td>";
                echo "<td>" . $row["Nome"] . "</td>";
                echo "<td>" . $row["Prezzo"] . "</td>";
                echo "<td>" . $row["Descrizione"] . "</td>";
                echo "<td>" . $row["Giacenza"] . "</td>";
                echo "</tr>";
            }
            echo "</table>";
        } else {
            echo "0 risultati";
        }
        mysqli_close($conn);
    }
    ?>
</div>
</body>
</html>
