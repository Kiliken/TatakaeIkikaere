using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Assertions;

/*
NETSTRINGS

type s:
    0(ServerStatus)

type r:
    0(ServerStatus)0(waitFlag)0000(testString)

*/

public static class NetManager
{
    //SERVER NAME
    public static readonly string SERVER = "http://baolotest.altervista.org/TTK/";


    /*public static readonly string CreateSession = $"{SERVER}createSession.php?";

    public static readonly string sendText = $"{SERVER}sendTest.php?";

    public static readonly string receveText = $"{SERVER}receveTest.php?";

    */

    //USE THIS

    public static readonly string getGameStart = $"{SERVER}getGameStart.php?";

    public static readonly string sendGameStart = $"{SERVER}sendGameStart.php?";

    public static readonly string sendData = $"{SERVER}sendData.php?";

    public static readonly string getData = $"{SERVER}getData.php?";

    public static readonly string checkFlag = $"{SERVER}checkFlag.php?";

    public static readonly string deleteSession = $"{SERVER}deleteSession.php?";


    //SERVER ASSERT
    public static void ASSERT(char status)
    {
        if (status == '1')
        {
            Debug.LogError("SERVER SIDE ERROR! CHECK PHP SIDE");

            #if UNITY_EDITOR
            if (EditorApplication.isPlaying)
            {
                UnityEditor.EditorApplication.isPlaying = false;
            }
            #endif


            return;
        }
    }
    /*
    public static NetData RetriveData(string str, char type) {
        NetData data = new NetData();
        char[] converter;
        switch(type) {
            case 's':
                converter = str.ToCharArray(0,str.Length);
                Debug.Log(str);

                data.sts = converter[0];
                break;
            case 'r':
                converter = str.ToCharArray(0,str.Length);
                Debug.Log(str);

                data.sts = converter[0];
                data.debugText = new string(converter, 1, converter.Length-1);
                break;
            case 'f':
                converter = str.ToCharArray(0,str.Length);
                Debug.Log(str);

                data.sts = converter[0];
                data.flag = converter[1];
                break;
            default:
                Debug.LogError("INVALID TYPE");
                return null;
        }
        return data;
    }*/
    //f

    public static NetData RetriveData(string str, char type)
    {
        NetData data = new NetData();
        char[] converter;
        switch (type)
        {
            case 'h':
                converter = str.ToCharArray(0, str.Length);
                Debug.Log(str);

                data.sts = converter[0];
                data.p2Hp = int.Parse(new string(converter, 1, 3));
                data.p2Atk = int.Parse(new string(converter, 4, 3));
                data.p2Spd = int.Parse(new string(converter, 7, 3));
                data.p1Spd = int.Parse(new string(converter, 10, 3));
                break;
            case 's':
                converter = str.ToCharArray(0, str.Length);
                Debug.Log(str);

                data.sts = converter[0];

                break;
            case 'r':
                converter = str.ToCharArray(0, str.Length);
                Debug.Log(str);

                data.sts = converter[0];
                data.p2Pos.x = int.Parse(new string(converter, 2, 1));
                data.p2Pos.y = int.Parse(new string(converter, 5, 1));
                data.p2UsedAtk = int.Parse(new string(converter, 7, 1));
                data.p2AtkCenter.x = int.Parse(new string(converter, 9, 1));
                data.p2AtkCenter.y = int.Parse(new string(converter, 12, 1));
                break;
            case 'f':
                converter = str.ToCharArray(0, str.Length);
                Debug.Log(str);

                data.sts = converter[0];
                data.flag = converter[1];
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

    //Server Stuff
    public char sts;
    public char flag;

    public int p1Spd;


    //Plyaer 2
    public int p2Hp;
    public int p2Atk;
    public int p2Spd;
    public Vector2Int p2Pos;
    public int p2UsedAtk;
    public Vector2Int p2AtkCenter;
}