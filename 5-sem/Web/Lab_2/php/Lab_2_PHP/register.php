<?php
require_once "DataBaseConnection.php";

$username = $password = "";
$username_err = $password_err = "";

if($_SERVER["REQUEST_METHOD"] == "POST")
{
    $conn = OpenCon();

    if(empty(trim($_POST["username"])))
    {
        $username_err = "Пожалуйста, введите имя пользователя.";
    } 
    elseif(!preg_match('/^[a-zA-Z0-9_]+$/', trim($_POST["username"])))
    {
        $username_err = "Имя пользователя может содержать только латинские буквы, цифры и нижнее подчёркивание.";
    } 
    else
    {
        $sql = "SELECT id FROM users WHERE username = ?";

        if($stmt = mysqli_prepare($conn, $sql))
        {
            mysqli_stmt_bind_param($stmt, "s", $param_username);

            $param_username = trim($_POST["username"]);

            if(mysqli_stmt_execute($stmt))
            {
                mysqli_stmt_store_result($stmt);

                if(mysqli_stmt_num_rows($stmt) == 1)
                {
                    $username_err = "Это имя пользователя занято";
                } 
                else
                {
                    $username = trim($_POST["username"]);
                }
            } 

            mysqli_stmt_close($stmt);
        }
    }

    if(empty(trim($_POST["password"])))
    {
        $password_err = "Пожалуйста, введите пароль";
    } 
    elseif(strlen(trim($_POST["password"])) < 6)
    {
        $password_err = "Пароль должен содержать хотя-бы 6 символов.";
    } 
    else
    {
        $password = trim($_POST["password"]);
    }


    if(empty($username_err) && empty($password_err))
    {
        $sql = "INSERT INTO users (username, password) VALUES (?, ?)";

        if($stmt = mysqli_prepare($conn, $sql))
        {
            mysqli_stmt_bind_param($stmt, "ss", $param_username, $param_password);

            $param_username = $username;
            $param_password = password_hash($password, PASSWORD_DEFAULT);

            if(mysqli_stmt_execute($stmt))
            {
                header("location: ../../index.html");
            } 
            mysqli_stmt_close($stmt);
        }
    }
    else
    {
        echo $username_err;
        echo "</br>";
        echo $password_err;
    }

    CloseCon($conn);
}
?>