<?php
header('Content-type: text/html; charset=utf-8');
include 'DataBaseConnection.php';

$username = $password = "";
$username_err = $password_err = $login_err = "";

if($_SERVER["REQUEST_METHOD"] == "POST")
{
    $conn = OpenCon();
    if(empty(trim($_POST["username"]))){
        $username_err = "Введите логин";
        die();
    } else{
        $username = trim($_POST["username"]);
    }

    if(empty(trim($_POST["password"]))){
        $password_err = "Введите пароль";
        die();
    } else{
        $password = trim($_POST["password"]);
    }
    if(empty($username_err) && empty($password_err))
    {
        $sql = "SELECT id, username, password FROM users WHERE username = ?";

        if($stmt = mysqli_prepare($conn, $sql))
        {
            mysqli_stmt_bind_param($stmt, "s", $param_username);

            $param_username = $username;

            if(mysqli_stmt_execute($stmt))
            {
                mysqli_stmt_store_result($stmt);

                if(mysqli_stmt_num_rows($stmt) == 1)
                {
                    mysqli_stmt_bind_result($stmt, $id, $username, $hashed_password);
                    if(mysqli_stmt_fetch($stmt))
                    {
                        if(password_verify($password, $hashed_password)){

                            session_start();
                            $_SESSION["loggedin"] = true;
                            $_SESSION["id"] = $id;
                            $_SESSION["username"] = $username;

                            header("location: form.html");
                        } 
                        else
                        {
                            $login_err = "Неправильный логин или пароль.";
                        }
                    }
                }
                else
                {
                    $login_err = "Неправильный логин или пароль.";
                }
            }

            mysqli_stmt_close($stmt);
        }
    }
    else
    {
        echo $login_err;
        echo "</br>";
        echo $password_err;
    }
    CloseCon($conn);
}
?>