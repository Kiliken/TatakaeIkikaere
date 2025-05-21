using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AtkSelectButton : MonoBehaviour
{
    [SerializeField] AtkSelectMenu selectMenu;
    public int attackNo = 1;
    public bool selected = false;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    public void SelectButtonPressed()
    {
        if (selected)
        {
            selectMenu.RemoveAttack(attackNo);
            GetComponent<Image>().enabled = false;
            selected = false;
        }
        else
        {
            if (selectMenu.selectionsLeft <= 0) return;

            selectMenu.AddAttack(attackNo);
            GetComponent<Image>().enabled = true;
            selected = true;
        }
    }
}
