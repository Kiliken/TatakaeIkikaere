using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AtkSelectMenu : MonoBehaviour
{
    [SerializeField] GameObject completeButton;
    [SerializeField] StatSave statSave;
    public int selectionsLeft = 4;
    public List<int> selectedAtk;
    // Start is called before the first frame update
    void Start()
    {
        statSave = GameObject.FindGameObjectWithTag("StatSave").GetComponent<StatSave>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddAttack(int atk)
    {
        selectedAtk.Add(atk);
        selectionsLeft -= 1;

        // check complete btn
        if (selectionsLeft <= 0)
        {
            completeButton.SetActive(true);
        }
    }

    public void RemoveAttack(int atk)
    {
        selectedAtk.Remove(atk);
        selectionsLeft += 1;

        // check complete btn
        if (selectionsLeft > 0)
        {
            completeButton.SetActive(false);
        }

    }

    public void OnCompleteBtnPressed()
    {
        selectedAtk.Sort();
        statSave.AtkTypes = selectedAtk.ToArray();
        SceneManager.LoadScene("Zayar2");
    }
}
