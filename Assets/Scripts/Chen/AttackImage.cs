using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackImage : MonoBehaviour
{
    public void resetMode()
    {
        //GameController.Instance.executeCurrentAction();
        Debug.Log("animation completed");
        GameController.Instance.animationComplete = true;

        
    }


}
