<!DOCTYPE html>
<html lang="en">
  <head>
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Document</title>
  </head>
  <body>
    <form name="FormRicerca" action="" method="post">
      <input type="number" name="ricerca" id="ricerca" />
      <input type="submit" value="Cerca" />
    </form>
    <!-- Show article -->
    <div id="articolo">
      <?php
        //In base al numero mostra gli articoli che costano meno di quel numero
        $conn = mysqli_Connect("localhost", "alexviolatto", "", "my_alexviolatto");
      ?>
    </div>
  </body>
</html>
