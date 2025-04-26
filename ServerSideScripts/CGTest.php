<?php
if($_GET["player"] == 1)
	echo "Hi player 1";
else
	echo "Hi player 2";

echo "PlayerHP = {$_GET["hp"]}";

$data["hp"] = $_GET["hp"];
$data["player"] = $_GET["player"];

$newJsonString = json_encode($data);
file_put_contents('gameSession.json', $newJsonString);
?>