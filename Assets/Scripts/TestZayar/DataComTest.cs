using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.Networking;

public class DataComTest : MonoBehaviour
{
    [SerializeField] GameController gameController;
    [SerializeField] int testHP = 0;
    [SerializeField] int testAtk = 0;
    [SerializeField] int testSpd = 0;
    [SerializeField] Vector2Int testPos;    // position that player is moving to
    [SerializeField] int testAtkType;   // attack type
    [SerializeField] Vector2Int testAtkCenter;  // attack center
    bool firstData = true;
    float refreshTime = 3f;
    float refreshTimer = 0f;
    bool dataSent = false;

    [Space(12)]
    [SerializeField] char playerSide; //Your Side



    // Start is called before the first frame update
    void Start()
    {
        //SendInitialData();
        StartCoroutine(SendInitialData($"id=123&side={playerSide}&hp={gameController.player1curHP}&atk={gameController.player1Atk}&spd={gameController.player1Speed}"));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N) && !dataSent)
        {
            StartCoroutine(SendNormalData($"id=123&side={playerSide}&hp={gameController.player1curHP}&pos={gameController.player1pos}&usedAtk={gameController.player1CurAtkType}&atkCtr={gameController.player1Center}"));

        }

        if (dataSent)
        {
            if (refreshTimer < refreshTime)
            {
                refreshTimer += Time.deltaTime;
            }
            else
            {
                StartCoroutine(NetCheckFlag($"id=123"));

                refreshTimer = 0f;
            }
        }


    }


    // called initially to set up data on the server
    public void SendInitialData()
    {
        testHP = gameController.player1curHP;
        testAtk = gameController.player1Atk;
        testSpd = gameController.player1Speed;

        // send the data to the server


    }


    public void SendNormalData()
    {
        testHP = gameController.player1curHP;
        testPos = gameController.player1pos;
        testAtkType = gameController.player1CurAtkType;
        testAtkCenter = gameController.player1Center;

        // send data to server
    }


    public void RetreiveInitialData()
    {
        // retreive data from server 


        gameController.player2curHP = testHP;
        gameController.player2Atk = testAtk;
        gameController.player2Speed = testSpd;
    }


    public void RetreiveNormalData()
    {
        // retreive data from server 

        gameController.player2curHP = testHP;
        gameController.player2pos = testPos;
        gameController.player2CurAtkType = testAtkType;
        gameController.player2Center = testAtkCenter;
    }

    IEnumerator RetreiveInitialData(string path)
    {



        UnityWebRequest uwr = UnityWebRequest.Get($"{NetManager.getGameStart}{path}");

        yield return uwr.SendWebRequest();

        if (uwr.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("ERROR: File not found");
            //RETURN TO MAIN MENU
        }
        else
        {


            if (firstData)
            {
                string results = uwr.downloadHandler.text;
                NetData data = NetManager.RetriveData(results, 'h');

                NetManager.ASSERT(data.sts);

                gameController.player2curHP = data.p2Hp;
                gameController.player2Atk = data.p2Atk;
                gameController.player2Speed = data.p2Spd;

                firstData = false;
                dataSent = false;
            }

        }

        uwr.Dispose();
    }

    IEnumerator NetCheckFlag(string path)
    {
        UnityWebRequest uwr = UnityWebRequest.Get($"{NetManager.checkFlag}{path}");


        yield return uwr.SendWebRequest();

        if (uwr.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("ERROR: File not found");
            //RETURN TO MAIN MENU
        }
        else
        {
            string results = uwr.downloadHandler.text;
            NetData data = NetManager.RetriveData(results, 'f');

            NetManager.ASSERT(data.sts);

            if (data.flag == '2' || data.flag == '3')
            {
                if (firstData)
                {
                    StartCoroutine(RetreiveInitialData($"id=123&side={playerSide}"));
                }
                else
                {
                    StartCoroutine(RetreiveNormalData($"id=123&side={playerSide}"));
                }


                //if not normal

            }

        }

        uwr.Dispose();
    }

    IEnumerator SendInitialData(string path)
    {
        UnityWebRequest uwr = UnityWebRequest.Get($"{NetManager.sendGameStart}{path}");


        yield return uwr.SendWebRequest();

        if (uwr.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("ERROR: File not found");
            //RETURN TO MAIN MENU
        }
        else
        {
            string results = uwr.downloadHandler.text;
            NetData data = NetManager.RetriveData(results, 's');

            NetManager.ASSERT(data.sts);

            dataSent = true;

        }

        uwr.Dispose();
    }

    IEnumerator SendNormalData(string path)
    {
        UnityWebRequest uwr = UnityWebRequest.Get($"{NetManager.sendData}{path}");


        yield return uwr.SendWebRequest();

        if (uwr.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("ERROR: File not found");
            //RETURN TO MAIN MENU
        }
        else
        {
            string results = uwr.downloadHandler.text;
            NetData data = NetManager.RetriveData(results, 's');

            NetManager.ASSERT(data.sts);

            dataSent = true;
        }

        uwr.Dispose();
    }
    
    IEnumerator RetreiveNormalData(string path)
   {
       UnityWebRequest uwr = UnityWebRequest.Get($"{NetManager.getData}{path}");


       yield return uwr.SendWebRequest();

       if (uwr.result != UnityWebRequest.Result.Success)
       {
           Debug.LogError("ERROR: File not found");
           //RETURN TO MAIN MENU
       }
       else
       {
           string results = uwr.downloadHandler.text;
           NetData data = NetManager.RetriveData(results, 'r');

           NetManager.ASSERT(data.sts);
            
            gameController.player2pos = data.p2Pos;
            gameController.player2CurAtkType = data.p2UsedAtk;
            gameController.player2Center = data.p2AtkCenter;

            dataSent = false;
            
       }

       uwr.Dispose();
   }
}
