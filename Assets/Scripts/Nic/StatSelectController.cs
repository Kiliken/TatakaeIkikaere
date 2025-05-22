using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine.SceneManagement;

public class StatSelectController : MonoBehaviour
{

    [SerializeField] GameObject completeButton;
    [SerializeField] StatSave statSave;

    public int statPool = 122;
    public int currentValueAtk = 100;
    public int currentValueHp = 100;
    public int currentValueSpd = 100;


    [SerializeField] private StatDigit statPoolDig1;
    [SerializeField] private StatDigit statPoolDig2;
    [SerializeField] private StatDigit statPoolDig3;

    [SerializeField] private StatDigit atkDig1;
    [SerializeField] private StatDigit atkDig2;
    [SerializeField] private StatDigit atkDig3;

    [SerializeField] private StatDigit hpDig1;
    [SerializeField] private StatDigit hpDig2;
    [SerializeField] private StatDigit hpDig3;

    [SerializeField] private StatDigit spdDig1;
    [SerializeField] private StatDigit spdDig2;
    [SerializeField] private StatDigit spdDig3;

    void Start()
    {
        Debug.Log("start");
        UpdateStatPool();
        UpdateAtk();
        UpdateHP();
        UpdateSpd();
        
    }


    public void UpdateAll()
    {
        UpdateStatPool();
        UpdateAtk();
        UpdateHP();
        UpdateSpd();
    }

    public void IncreaseAtk()
    {
        Debug.Log("increase atk");
        if (statPool >= 10)
        {
            currentValueAtk += 10;
            statPool -= 10;
            //atkText.text = currentValueAtk.ToString();
            //statPoolText.text = statPool.ToString();
            
            

            if (statPool == 0) SetCompleteBtn(true);
        }

        UpdateAll();
    }

    public void DecreaseAtk()
    {
        if (currentValueAtk >= 110)
        {
            currentValueAtk -= 10;
            statPool += 10;
            //atkText.text = currentValueAtk.ToString();
            //statPoolText.text = statPool.ToString();

            if (statPool > 0) SetCompleteBtn(false);
        }

        UpdateAll();
    }

   


    public void IncreaseHp()
    {
        if (statPool >= 10)
        {
            currentValueHp += 10;
            statPool -= 10;
            //hpText.text = currentValueHp.ToString();
            //statPoolText.text = statPool.ToString();


            if (statPool == 0) SetCompleteBtn(true);
        }
        UpdateAll();
    }

    public void DecreaseHp()
    {
        if (currentValueHp >= 110)
        {
            currentValueHp -= 10;
            statPool += 10;
            //hpText.text = currentValueHp.ToString();
            //statPoolText.text = statPool.ToString();

            if (statPool > 0) SetCompleteBtn(false);
        }
        UpdateAll();
    }



    public void IncreaseSpd()
    {
        if (statPool >= 10)
        {
            currentValueSpd += 10;
            statPool -= 10;
            //spdText.text = currentValueSpd.ToString();
            //statPoolText.text = statPool.ToString();


            if (statPool == 0) SetCompleteBtn(true);
        }
        UpdateAll();
    }

    public void DecreaseSpd()
    {
        if (currentValueSpd >= 110)
        {
            currentValueSpd -= 10;
            statPool += 10;
            //spdText.text = currentValueSpd.ToString();
            //statPoolText.text = statPool.ToString();



            if (statPool > 0) SetCompleteBtn(false);
        }
        UpdateAll();
    }

    private void UpdateAtk()
    {
        atkDig1.UpdateDigit(currentValueAtk / 100);
        atkDig2.UpdateDigit((currentValueAtk / 10) % 10);
        atkDig3.UpdateDigit((currentValueAtk % 100) % 10);
    }

    private void UpdateHP()
    {
        hpDig1.UpdateDigit(currentValueHp / 100);
        hpDig2.UpdateDigit((currentValueHp / 10) % 10);
        hpDig3.UpdateDigit((currentValueHp % 100) % 10);
    }

    private void UpdateSpd()
    {
        spdDig1.UpdateDigit(currentValueSpd / 100);
        spdDig2.UpdateDigit((currentValueSpd / 10) % 10);
        spdDig3.UpdateDigit((currentValueSpd % 100) % 10);
    }

    private void UpdateStatPool()
    {
        statPoolDig1.UpdateDigit(statPool / 100);
        Debug.Log("2nd digit: " + ((statPool / 10) % 10));
        statPoolDig2.UpdateDigit((statPool / 10) % 10);
        statPoolDig3.UpdateDigit((statPool % 100) % 10);
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
