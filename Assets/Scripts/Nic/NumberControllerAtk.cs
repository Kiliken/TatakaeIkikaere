using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine.SceneManagement;

public class NumberControllerAtk : MonoBehaviour
{
    public TextMeshProUGUI atkText;
    public TextMeshProUGUI hpText;
    public TextMeshProUGUI spdText;
    public TextMeshProUGUI statPoolText;
    [SerializeField] GameObject completeButton;
    [SerializeField] StatSave statSave;

    public int statPool = 100;
    public int currentValueAtk = 100;
    public int currentValueHp = 100;
    public int currentValueSpd = 100;

    public void IncreaseAtk()
    {
        if (statPool >= 10)
        {
            currentValueAtk += 10;
            statPool -= 10;
            atkText.text = currentValueAtk.ToString();
            statPoolText.text = statPool.ToString();
            if (statPool == 0) SetCompleteBtn(true);
        }
    }

    public void DecreaseAtk()
    {
        if (currentValueAtk >= 110)
        {
            currentValueAtk -= 10;
            statPool += 10;
            atkText.text = currentValueAtk.ToString();
            statPoolText.text = statPool.ToString();
            if (statPool > 0) SetCompleteBtn(false);
        }
    }

    public void IncreaseHp()
    {
        if (statPool >= 10)
        {
            currentValueHp += 10;
            statPool -= 10;
            hpText.text = currentValueHp.ToString();
            statPoolText.text = statPool.ToString();
            if (statPool == 0) SetCompleteBtn(true);
        }
    }

    public void DecreaseHp()
    {
        if (currentValueHp >= 110)
        {
            currentValueHp -= 10;
            statPool += 10;
            hpText.text = currentValueHp.ToString();
            statPoolText.text = statPool.ToString();
            if (statPool > 0) SetCompleteBtn(false);
        }
    }

    public void IncreaseSpd()
    {
        if (statPool >= 10)
        {
            currentValueSpd += 10;
            statPool -= 10;
            spdText.text = currentValueSpd.ToString();
            statPoolText.text = statPool.ToString();
            if (statPool == 0) SetCompleteBtn(true);
        }
    }

    public void DecreaseSpd()
    {
        if (currentValueSpd >= 110)
        {
            currentValueSpd -= 10;
            statPool += 10;
            spdText.text = currentValueSpd.ToString();
            statPoolText.text = statPool.ToString();
            if (statPool > 0) SetCompleteBtn(false);
        }
    }

    private void UpdateUI()
    {
        // if (statPool=0) {

        // }
    }

    private void SetCompleteBtn(bool enabled)
    {
        completeButton.SetActive(enabled);
    }

    public void OnCompleteBtnPressed()
    {
        statSave.Atk = currentValueAtk;
        statSave.maxHP = currentValueHp;
        statSave.Speed = currentValueSpd;
        SceneManager.LoadScene("AtkSelectScene");
    }
}
