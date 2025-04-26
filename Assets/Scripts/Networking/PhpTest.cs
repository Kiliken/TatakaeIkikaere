
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class PhpTest : MonoBehaviour
{
    [SerializeField]
    int hp = 0;

    [SerializeField] 
    private Text _text;

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

        if (_timer >= 3f)
        {
            StartCoroutine(ReadCSVFromWeb($"http://baolotest.altervista.org/CGTest.php?player=1&hp={hp}"));
            _timer = 0;
        }

        if (Input.GetKeyUp(KeyCode.G))
        {
            StartCoroutine(ReadCSVFromWeb($"http://baolotest.altervista.org/CGTest.php?player=1&hp={hp}"));
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
        }
        else
        {
            string results = uwr.downloadHandler.text;

            _text.text = results;

        }

        uwr.Dispose();
    }
}
