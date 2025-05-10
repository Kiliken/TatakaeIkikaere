using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public static class NetManager {
    //SERVER NAME
    public static readonly string SERVER = "http://baolotest.altervista.org/";

    public static readonly string CreateSession = $"{SERVER}createSession.php?";

    public static readonly string sendText = $"{SERVER}sendTest.php?";

    public static readonly string receveText = $"{SERVER}receveTest.php?";


    //SERVER ASSERT
    public static void ASSERT(bool status)
    {
        if (status)
        {
            Debug.LogError("SERVER SIDE ERROR! CHECK PHP SIDE");
            //RETURN MAIN MENU
            return;
        }
    }
}


public class JsonMessage
{
    
    public bool sts;

    //Session id
    public string id;
    //DEBUG TEST
    public string RText;
    public string BText;
}


