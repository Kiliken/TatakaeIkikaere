<?php
$str = file_get_contents("./Sessions/S{$_GET["id"]}.json");
$data = json_decode($str, true);


//flag should start at 2
//player side
$pS = $_GET["side"];

switch($pS){
	case 'r':
    	$hp = $data["player"]["b"]["hp"];
        $atk = $data["player"]["b"]["atk"];
        $spd = $data["player"]["b"]["spd"];
    	break;
    case 'b':
    	$hp = $data["player"]["r"]["hp"];
        $atk = $data["player"]["r"]["atk"];
        $spd = $data["player"]["r"]["spd"];
    	break;
}

$data["flag"] +=1;

if ($data["flag"] == 4)
	$data["flag"] = 0;
    
$newJsonString = json_encode($data);
file_put_contents("./Sessions/S{$_GET["id"]}.json", $newJsonString);

echo "0{$hp}{$atk}{$spd}";

/*
echo <pre>
var_dump($data);




?>