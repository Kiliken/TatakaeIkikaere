using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

/*
NETSTRINGS

type s:
    0(ServerStatus)

type r:
    0(ServerStatus)0(waitFlag)0000(testString)

*/

public static class NetManager {
    //SERVER NAME
    public static readonly string SERVER = "http://baolotest.altervista.org/";

    public static readonly string CreateSession = $"{SERVER}createSession.php?";

    public static readonly string sendText = $"{SERVER}sendTest.php?";

    public static readonly string receveText = $"{SERVER}receveTest.php?";

    public static readonly string clearFlag = $"{SERVER}clearFlag.php?";


    //SERVER ASSERT
    public static void ASSERT(char status)
    {
        if (status == '1')
        {
            Debug.LogError("SERVER SIDE ERROR! CHECK PHP SIDE");
            //RETURN MAIN MENU
            return;
        }
    }

    public static NetData RetriveData(string str, char type) {
        NetData data = new NetData();
        char[] converter;
        switch(type) {
            case 's':
                converter = str.ToCharArray(0,str.Length);
                data.sts = converter[0];
                break;
            case 'r':
                converter = str.ToCharArray(0,str.Length);
                data.sts = converter[0];
                data.flag = converter[1];
                if (data.flag != '2')
                    break;

                data.debugText = new string(converter, 2, 5);
                break;
            default:
                Debug.LogError("INVALID TYPE");
                return null;
        }
        return data;
    }
}


public class NetData
{
    
    public char sts;
    public char[] id;

    public char flag;
    //DEBUG TEST
    public string debugText;
}


