<?php
$str = file_get_contents("./Sessions/S{$_GET["id"]}.json");
$data = json_decode($str, true);

//player side

	
echo "0{$data["flag"]}";

/*
echo <pre>
var_dump($data);




?>