<?php
$str = file_get_contents("./Sessions/S{$_GET["id"]}.json");
$data = json_decode($str, true);

//player side
$pS = $_GET["side"];

if(isset($_GET["pos"])) {
	$data["player"][$pS]["pos"] = strval($_GET["pos"]);
}

if(isset($_GET["usedAtk"])) {
	$data["player"][$pS]["usedAtk"] = $_GET["usedAtk"];
}

if(isset($_GET["atkCtr"])) {
	$data["player"][$pS]["atkCtr"] = strval($_GET["atkCtr"]);
}

//if the flag is 2 || 3 ASSERT
if($data["flag"] >= 2 || $data["flag"] < 0){
	echo "1";
    return;
}


$data["flag"] += 1;


$newJsonString = json_encode($data);
file_put_contents("./Sessions/S{$_GET["id"]}.json", $newJsonString);
	
echo 0;

/*
echo <pre>
var_dump($data);




?>