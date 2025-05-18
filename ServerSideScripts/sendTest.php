<?php
$str = file_get_contents("./Sessions/S{$_GET["id"]}.json");
$data = json_decode($str, true);

//player side
$pS = $_GET["side"];

if(isset($_GET["text"])) {
	$data["player"][$pS]["text"] = substr($_GET["text"], 1);
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