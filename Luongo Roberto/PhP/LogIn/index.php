<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Document</title>
    <style>
        body{
            margin: 0;
            padding: 0;
            box-sizing: border-box;
            font-family: Arial, sans-serif;
            background-image: url('https://img.freepik.com/free-photo/abstract-digital-grid-black-background_53876-97647.jpg?w=996&t=st=1712733736~exp=1712734336~hmac=a8b8fa41263ccf77d5f79c3b52ecdca6c30db9f3ed4d3cbe68732f2f1d4a31b2');
        }
        .container{
            width: 100%;
            height: 100vh;
            display: flex;
            justify-content: center;
            align-items: center;
        }
        form{
            display: flex;
            flex-direction: column;
        }
        input{
            margin: 10px;
            padding: 10px;
            border: 1px solid #000;
            border-radius: 5px;
        }
        input[type="submit"]{
            background-color: white;
            color: black;
            cursor: pointer;
        }
    </style>
</head>
<body>
<div class="container">
<form name="FormLogin" action="" method="post">
    <input type="text" name="username" placeholder="Username">
    <input type="password" name="password" placeholder="Password">
    <input type="submit" name="submit" value="Login">
</form>
</div>
<?php
    if(isset($_POST['submit'])){
        $conn = mysqli_connect("localhost", "alexviolatto", "X3D6NqedZ97t", "my_alexviolatto");
        if(!$conn){
            die("Connection failed: ".mysqli_connect_error());
        }
        $username = $_POST['username'];
        $password = $_POST['password'];
        echo $username."<br>";
        echo $password."<br>";
        $sql = "SELECT * FROM Login WHERE Email = '$username' AND Password = '$password'";
        $result = mysqli_query($conn, $sql);
        if(mysqli_num_rows($result) > 0){
            echo "Login successfully";
        }else{
            echo "Login failed";
        }
    }
?>
</body>
</html>