<?php
$serverName = "(localdb)\MSSQLLocalDB";
$connection = array("Database"=>"php");

$conn = sqlsrv_connect($serverName,$connection);

$sql = "SELECT * FROM dat";
$stmt = sqlsrv_query($conn, $sql);

if ($stmt === false) {
   echo "Error in statement preparation/execution.\n";
   die(print_r(sqlsrv_errors(), true));
}

while( $row = sqlsrv_fetch_array( $stmt, SQLSRV_FETCH_ASSOC))  
{  
      echo $row['id'].", ".$row['tag1_sin'].", ".$row['tag2_sin'].", ".$row['tag3_sin']."/";  
}  

sqlsrv_close($conn);


?>