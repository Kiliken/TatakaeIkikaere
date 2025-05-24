<?php
$str = file_get_contents("./Sessions/S{$_GET["id"]}.json");
$data = json_decode($str, true);

//player side
$pS = $_GET["side"];

switch($pS){
	case 'r':
    	$pos = $data["player"]["b"]["pos"];
        $usedAtk = $data["player"]["b"]["usedAtk"];
        $atkCtr = $data["player"]["b"]["atkCtr"];
    	break;
    case 'b':
    	$pos = $data["player"]["r"]["pos"];
        $usedAtk = $data["player"]["r"]["usedAtk"];
        $atkCtr = $data["player"]["r"]["atkCtr"];
    	break;
}

$data["flag"] +=1;

if ($data["flag"] == 4)
	$data["flag"] = 0;
    
$newJsonString = json_encode($data);
file_put_contents("./Sessions/S{$_GET["id"]}.json", $newJsonString);

echo "0{$pos}{$usedAtk}{$atkCtr}";

/*
echo <pre>
var_dump($data);




?>