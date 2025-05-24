<?php
$str = file_get_contents("./Sessions/S{$_GET["id"]}.json");
$data = json_decode($str, true);


$data["skadoosh"] += 1;

if($data["skadoosh"] >= 2) {
	unlink("./Sessions/S{$_GET["id"]}.json");
    echo 0;
    return;
}


$newJsonString = json_encode($data);
file_put_contents("./Sessions/S{$_GET["id"]}.json", $newJsonString);
	
echo 0;

/*
echo <pre>
var_dump($data);




?>