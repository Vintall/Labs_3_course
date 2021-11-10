<?php
include 'DataBaseConnection.php';
session_start();


if(!isset($_SESSION["loggedin"]) || $_SESSION["loggedin"] !== true)
{
    header("location: login.php");
    exit;
}
else
{
    $conn = OpenCon();
    if ($_SERVER["REQUEST_METHOD"] == "POST") {

        $name = "";
        $mail = "";
        $message = "";
        $checkbox = "";
        $color = "";
        $date = "";
        $number = "";
        $radio = "";
        $user_range = "";
        $user_week = "";
        $user_tel = "";

        if(!empty($_POST['user_name']))
            $name = $_POST['user_name'];

        if(!empty($_POST['user_mail']))
            $mail = $_POST['user_mail'];

        if(!empty($_POST['user_message']))
            $message = $_POST['user_message'];

        if(!isset($_POST['checkbox']))
            $checkbox = "off";
        else
            $checkbox = $_POST['checkbox'];

        $color = $_POST['user_color'];
        $date = $_POST['user_date'];
        $number = $_POST['user_number'];

        if(isset($_POST['user_radio']))
            $radio = $_POST["user_radio"];

        $user_range = $_POST['user_range'];
        $user_week = $_POST['user_week'];
        $user_tel = $_POST['user_tel'];

        //echo $name;
        //echo "</br>";
        //echo $mail;
        //echo "</br>";
        //echo $message;
        //echo "</br>";
        //echo $checkbox;
        //echo "</br>";
        //echo $color;
        //echo "</br>";
        //echo $date;
        //echo "</br>";
        //echo $number;
        //echo "</br>";
        //echo $radio;
        //echo "</br>";
        //echo $user_range;
        //echo "</br>";
        //echo $user_week;
        //echo "</br>";
        //echo $user_tel;
        //echo "</br>";
        //echo "</br>";
        //echo  $_SESSION["loggedin"];
        //echo "</br>";
        //echo  $_SESSION["id"];
        //echo "</br>";
        //echo  $_SESSION["username"];


        $sql = " UPDATE users SET form_name='".$name."' WHERE id = " . $_SESSION["id"];
        mysqli_query($conn, $sql);

        $sql = " UPDATE users SET form_mail='". $mail ."' WHERE id = " . $_SESSION["id"];
        mysqli_query($conn, $sql);

        $sql = " UPDATE users SET form_text='".$message."' WHERE id = " . $_SESSION["id"];
        mysqli_query($conn, $sql);

        $sql = " UPDATE users SET form_checkbox='".$checkbox."' WHERE id = " . $_SESSION["id"];
        mysqli_query($conn, $sql);

        $sql = " UPDATE users SET form_color='".$color."' WHERE id = " . $_SESSION["id"];
        mysqli_query($conn, $sql);

        $sql = " UPDATE users SET form_date='". $date ."' WHERE id = " . $_SESSION["id"];
        mysqli_query($conn, $sql);

        $sql = " UPDATE users SET form_number='".$number."' WHERE id = " . $_SESSION["id"];
        mysqli_query($conn, $sql);

        $sql = " UPDATE users SET form_radio='".$radio."' WHERE id = " . $_SESSION["id"];
        mysqli_query($conn, $sql);

        $sql = " UPDATE users SET form_range='".$user_range."' WHERE id = " . $_SESSION["id"];
        mysqli_query($conn, $sql);

        $sql = " UPDATE users SET form_week='".$user_week."' WHERE id = " . $_SESSION["id"];
        mysqli_query($conn, $sql);

        $sql = " UPDATE users SET form_telephone='".$user_tel."' WHERE id = " . $_SESSION["id"];
        mysqli_query($conn, $sql);

        header("location: DataFromSQL.php");
    }
    CloseCon($conn);
}
?>