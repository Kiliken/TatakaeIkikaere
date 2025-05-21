using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // public void PlayGame()
    // {
    //     Debug.Log("pressed");
    //     SceneManager.LoadScene("Zayar2");
    // }

    public void LoadStatSelection()
    {
        SceneManager.LoadScene("StatSelectScene");
    }


    public void QuitGame()
    {
        Application.Quit();
    }
}
