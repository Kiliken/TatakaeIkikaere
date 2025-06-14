using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButton : MonoBehaviour
{
    public GameObject notPressedObj;

    public float pressDuration = 0.5f;


    public void OnClick()
    {
        StartCoroutine(PressRoutine());
        GameController.Instance.back();
    }

    private IEnumerator PressRoutine()
    {
        notPressedObj.SetActive(false);
        yield return new WaitForSeconds(pressDuration);
        notPressedObj.SetActive(true);
        GameController.Instance.UpdateAction();
    }
}
