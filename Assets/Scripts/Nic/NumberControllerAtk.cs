using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NumberControllerAtk : MonoBehaviour
{
    public Text numberText;

    private int currentValue = 100;

    public void Increase()
    {
        currentValue++;
        UpdateUI();
    }

    public void Decrease()
    {
        currentValue--;
        UpdateUI();
    }

    private void UpdateUI()
    {
        numberText.text = currentValue.ToString();
    }
}
