using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NumberControllerAtk : MonoBehaviour
{
    public TextMeshProUGUI atkText;
    public TextMeshProUGUI hpText;
    public TextMeshProUGUI spdText;
    public TextMeshProUGUI statPoolText;

    public int statPool = 100;
    public int currentValueAtk = 100;
    public int currentValueHp = 100;
    public int currentValueSpd = 100;

    public void IncreaseAtk()
    {
        if (statPool>=10) {
          currentValueAtk+=10;
          statPool-=10;
          atkText.text = currentValueAtk.ToString();
          statPoolText.text = statPool.ToString();
        }
    }

    public void DecreaseAtk()
    {
        if (currentValueAtk>=110) {
            currentValueAtk-=10;
            statPool+=10;
            atkText.text = currentValueAtk.ToString();
            statPoolText.text = statPool.ToString();
        }
    }

    public void IncreaseHp()
    {
        if (statPool>=10) {
          currentValueHp+=10;
          statPool-=10;
          hpText.text = currentValueHp.ToString();
          statPoolText.text = statPool.ToString();
        }
    }

    public void DecreaseHp()
    {
        if (currentValueHp>=110) {
            currentValueHp-=10;
            statPool+=10;
            hpText.text = currentValueHp.ToString();
            statPoolText.text = statPool.ToString();
        }
    }

    public void IncreaseSpd()
    {
        if (statPool>=10) {
          currentValueSpd+=10;
          statPool-=10;
          spdText.text = currentValueSpd.ToString();
          statPoolText.text = statPool.ToString();
        }
    }

    public void DecreaseSpd()
    {
        if (currentValueSpd>=110) {
            currentValueSpd-=10;
            statPool+=10;
            spdText.text = currentValueSpd.ToString();
            statPoolText.text = statPool.ToString();
        }
    }

    private void UpdateUI()
    {
        // if (statPool=0) {
            
        // }
    }
}
