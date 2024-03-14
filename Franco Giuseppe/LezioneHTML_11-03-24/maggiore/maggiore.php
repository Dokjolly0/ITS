<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Document</title>
</head>
<body>
    <?php
        function Maggiore($num1, $num2, $num3) {
            if ($num1 > $num2 && $num1 > $num3)
                return $num1;
            elseif ($num2 > $num1 && $num2 > $num3)
                return $num2;
            else
                return $num3;
        }

        $NumeroMaggiore = Maggiore($_POST["num1"], $_POST["num2"], $_POST["num3"]);
        print ("Il Maggiore e: $NumeroMaggiore");
    ?>
</body>
</html>