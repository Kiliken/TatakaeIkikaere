<?php
	$data["id"] = $_GET["id"];
    
    
	
    if (file_exists("Sessions/S{$data["id"]}.json"))
    {
    	$response["sts"] = 1;
        $jsonData = json_encode($response);
        echo $jsonData;
    }
    	
    else {
    	
        
		$jsonData = json_encode($data);
		file_put_contents("Sessions/S{$data["id"]}.json", $jsonData);
    
    	$response["id"] = $data["id"];
        $response["sts"] = 0;
        $jsonData = json_encode($response);
    	echo $jsonData;
		
	}

?>