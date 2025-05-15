using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfirmButton : MonoBehaviour
{

    public GameObject notPressedObj;

    public float pressDuration = 1f;

    public void OnClick()
    {
        StartCoroutine(PressRoutine());
        GameController.Instance.executeCurrentAction();
        //GameController.Instance.UpdateAction();
    }
    
    private IEnumerator PressRoutine()
    {
        notPressedObj.SetActive(false);
        yield return new WaitForSeconds(pressDuration);
        notPressedObj.SetActive(true);
    }
}
