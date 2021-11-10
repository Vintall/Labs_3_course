<?php
include 'config.php';
function OpenCon()
{
    $conn = new mysqli(DB_SERVER, DB_USERNAME, DB_PASSWORD, DB_NAME);

    if ($conn->connect_error)
    {
        die("Connection failed: ");
    }
    return $conn;
}

function CloseCon($conn)
 {
 $conn -> close();
 }

?>