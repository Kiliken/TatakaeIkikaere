
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class PhpTest : MonoBehaviour
{
    [SerializeField]
    int hp = 0;

    [SerializeField] 
    private UnityEngine.UI.Text _text;

    float _timer = 0f;


    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(ReadCSVFromWeb());
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;

        /*if (_timer >= 3f)
        {
            StartCoroutine(ReadCSVFromWeb($"{NetManager.CreateSession}id=222"));
            _timer = 0;
        }*/

        if (Input.GetKeyUp(KeyCode.G))
        {
            StartCoroutine(ReadCSVFromWeb($"{NetManager.sendText}id=123"));
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            StartCoroutine(ReadCSVFromWeb($"http://baolotest.altervista.org/gameSession.json"));
        }
    }

    IEnumerator ReadCSVFromWeb(string path)
    {
        UnityWebRequest uwr = UnityWebRequest.Get(path);


        yield return uwr.SendWebRequest();

        if (uwr.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("ERROR: File not found");
            //RETURN TO MAIN MENU
        }
        else
        {
            string results = uwr.downloadHandler.text;
            //var data = JsonUtility.FromJson<JsonMessage>(results);
            Debug.Log(results);

            //NetManager.ASSERT(data.sts);

            //DO SOMETHING
            //_text.text = $"{data.RText}";


        }

        uwr.Dispose();
    }
}
