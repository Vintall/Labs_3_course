<?php
include 'DataBaseConnection.php';
session_start();

    $conn = OpenCon();

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

    $sql = "SELECT * FROM users WHERE id = '" . $_SESSION["id"] . "'";
    $result = mysqli_query($conn, $sql);
    $row = $result->fetch_assoc();

    $name = $row["form_name"];
    $mail = $row["form_mail"];
    $message = $row["form_text"];
    $checkbox = $row["form_checkbox"];
    $color = $row["form_color"];
    $date = $row["form_date"];
    $number = $row["form_number"];
    $radio = $row["form_radio"];
    $user_range = $row["form_range"];
    $user_week = $row["form_week"];
    $user_tel = $row["form_telephone"];

CloseCon($conn);
?>

<!DOCTYPE html>
<html lang="ru">
<head>
    <meta charset="UTF-8" />
    <title>SQLBack</title>
    <style>
        body{ font: 14px sans-serif; background-color:#D4D664; }
        .wrapper{ display:block; width: 360px; padding: 20px; margin-right:auto; margin-left:auto;}
        .taking_data { text-align:center; margin: 0 auto;
  width: 300px;
  padding: 10px;
  border: 1px solid #CCC;
  border-radius: 1em;
  display: block;
  font-size:15px;
        }
        .center_button {
            display: block;
            margin-left: auto;
            margin-right: auto;
            width: 10%;
            padding: 10px;
        }
    </style>
</head>
<body>
    <button class="center_button" onclick="location.href='../../index.html'"> Вернуться в главное меню </button>
    <div class="wrapper">
        <?php
            echo '<div class="taking_data"> Имя: ' . $name . '</div>';

            echo '<div class="taking_data"> Имейл: ' . $mail . '</div>';

            echo '<div class="taking_data"> Сообщение: ' . $message . '</div>';

            echo '<div class="taking_data"> Ставили галочку? ';
            if($checkbox === "on")
                echo 'Да';
            else
                echo 'Нет';
            echo '</div>';

            echo '<div class="taking_data"> Цвет: ' . $color . '</div>';

            echo '<div class="taking_data"> Когда: ' . $date . '</div>';

            echo '<div class="taking_data"> Столько: ' . $number . '</div>';

            echo '<div class="taking_data"> Пол ';
            if($radio === "on")
                echo 'присутствует';
            else
                echo 'отсутствует';
            echo '</div>';

            echo '<div class="taking_data"> И какой ответ (sqrt(841))? ' . $user_range . '</div>';

            echo '<div class="taking_data"> Неделя: ' . $user_week . '</div>';
            echo '<div class="taking_data"> Телефон: ' . $user_tel . '</div>';
        ?>

    </div>
</body>
</html>