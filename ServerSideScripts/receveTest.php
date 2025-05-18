<?php
$str = file_get_contents("./Sessions/S{$_GET["id"]}.json");
$data = json_decode($str, true);

//player side
$pS = $_GET["side"];

switch($pS){
	case 'r':
    	$text = $data["player"]["b"]["text"];
    	break;
    case 'b':
    	$text = $data["player"]["r"]["text"];
    	break;
}

$data["flag"] +=1;

if ($data["flag"] == 4)
	$data["flag"] = 0;
    
$newJsonString = json_encode($data);
file_put_contents("./Sessions/S{$_GET["id"]}.json", $newJsonString);

echo "0{$text}";

/*
echo <pre>
var_dump($data);




?>