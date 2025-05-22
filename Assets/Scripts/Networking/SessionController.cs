using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SessionController : MonoBehaviour
{
    [SerializeField] GameObject createButton;
    [SerializeField] GameObject joinButton;
    [SerializeField] StatSave statSave;
    [SerializeField] TextMeshProUGUI idString;
    public int sessionId = 0;
    char[] player = { 'b', 'r' };

    string test = "000";
    // Start is called before the first frame update
    void Start()
    {
        statSave = GameObject.FindGameObjectWithTag("StatSave").GetComponent<StatSave>();
    }

    private void Update()
    {
        if (idString.text.Length < 4)
        {
            createButton.SetActive(false);
            joinButton.SetActive(false);
        }
        else
        {
            createButton.SetActive(true);
            joinButton.SetActive(true);
            
        }

    }


    public void OnCreateSession()
    {
        test = idString.text;
        //sessionId = Int32.Parse(test);
        char[] test2 = test.ToCharArray(0, test.Length);
        sessionId = int.Parse(new string(test2, 0, 3));
        statSave.sessionId = sessionId;
        statSave.playerSide = player[0];
        SceneManager.LoadScene("Zayar2");
    }

    public void OnJoinSession()
    {
        test = idString.text;
        //sessionId = Int32.Parse(test);
        char[] test2 = test.ToCharArray(0, test.Length);
        sessionId = int.Parse(new string(test2, 0, 3));
        statSave.sessionId = sessionId;
        statSave.playerSide = player[1];
        SceneManager.LoadScene("Zayar2");
    }
}
