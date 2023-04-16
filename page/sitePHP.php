
<?php   
// php -S localhost:8000 page/sitePHP.php

    $hostname = "127.0.0.1:1433";
    $db="AutomationDB";
    $db2="DBAut";
    $username="Roland";
    $passwd="Roland";


    $conn = mysqli_connect($hostname,$username,$passwd,$db);
    //phpinfo();
    $mysqli -> close();

?>
