//using System.Collections;
//using System.Collections.Generic;
//using TMPro;
//using UnityEngine;
//using UnityEngine.Networking;

//public class MessageManager : MonoBehaviour
//{

//    [SerializeField] TextMeshProUGUI p1Text;
//    [SerializeField] TextMeshProUGUI p2Text;
//    private bool typing = false;
//    public string p1Message;
//    public string p2Message;

//    [SerializeField] char playerSide = 'r';
//    float messageTime = 3f;
//    float messageTimer = 0f;
//    private bool dataSent = false;


//    // Start is called before the first frame update
//    void Start()
//    {
        
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        if (dataSent)
//        {
//            if (messageTimer < messageTime)
//            {
//                messageTimer += Time.deltaTime;
//            }
//            else
//            {
//                // SEND DATA TO PHP
//                SendData();
//                // RECEIVE DATA FROM PHP
//                if (dataSent)
//                    StartCoroutine(NetCheckFlag($"id=123"));

//                messageTimer = 0f;
                
//            }
//        }
        

//        if (Input.GetKeyDown(KeyCode.Return))
//        {
//            if (!typing)
//            {
//                typing = true;
//                p1Text.text = "";
//                Debug.Log("Typing");
//            }
//            else
//            {
//                // send data and cancel typing
//                typing = false;
//                Debug.Log("Typing canceled");

//            }
//        }

//        // get player text input
//        if (typing)
//        {
//            foreach (char c in Input.inputString)
//            {
//                if (c == '\b') // has backspace/delete been pressed?
//                {
//                    if (p1Text.text.Length != 0)
//                    {
//                        p1Text.text = p1Text.text.Substring(0, p1Text.text.Length - 1);
//                    }
//                }
//                else
//                {
//                    p1Text.text += c;
//                }
//            }
//        }
//    }

//    public void SendData()
//    {
//        if(dataSent) return;

//        p1Message = p1Text.text;
//        Debug.Log("Sending data...");
//        StartCoroutine(NetSendMessage($"id=123&side={playerSide}&text={p1Message}"));
//    }

//    IEnumerator NetSendMessage(string path)
//    {
//        UnityWebRequest uwr = UnityWebRequest.Get($"{NetManager.sendText}{path}");


//        yield return uwr.SendWebRequest();

//        if (uwr.result != UnityWebRequest.Result.Success)
//        {
//            Debug.LogError("ERROR: File not found");
//            //RETURN TO MAIN MENU
//        }
//        else
//        {
//            string results = uwr.downloadHandler.text;
//            NetData data = NetManager.RetriveData(results, 's');

//            NetManager.ASSERT(data.sts);

//            dataSent = true;
//        }

//        uwr.Dispose();
//    }

//    IEnumerator NetReceiveMessage(string path)
//    {
//        UnityWebRequest uwr = UnityWebRequest.Get($"{NetManager.receveText}{path}");


//        yield return uwr.SendWebRequest();

//        if (uwr.result != UnityWebRequest.Result.Success)
//        {
//            Debug.LogError("ERROR: File not found");
//            //RETURN TO MAIN MENU
//        }
//        else
//        {
//            string results = uwr.downloadHandler.text;
//            NetData data = NetManager.RetriveData(results, 'r');

//            NetManager.ASSERT(data.sts);
            
//            p2Message = data.debugText;
//            p2Text.text = p2Message;
//            dataSent = false;
            
//        }

//        uwr.Dispose();
//    }

//    IEnumerator NetCheckFlag(string path)
//    {
//        UnityWebRequest uwr = UnityWebRequest.Get($"{NetManager.checkFlag}{path}");


//        yield return uwr.SendWebRequest();

//        if (uwr.result != UnityWebRequest.Result.Success)
//        {
//            Debug.LogError("ERROR: File not found");
//            //RETURN TO MAIN MENU
//        }
//        else
//        {
//            string results = uwr.downloadHandler.text;
//            NetData data = NetManager.RetriveData(results, 'f');

//            NetManager.ASSERT(data.sts);

//             if(data.flag == '2' || data.flag == '3')
//            {
//                StartCoroutine(NetReceiveMessage($"id=123&side={playerSide}"));

//            }   
            
//        }

//        uwr.Dispose();
//    }
//}
