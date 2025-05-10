using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackImage : MonoBehaviour
{
    public void resetMode()
    {
        GameController.Instance.resetMode();
        //this.gameObject.SetActive(false );
        AttackController.Instance.center = new Vector2Int(1,1);
    }

}
