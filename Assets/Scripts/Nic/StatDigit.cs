using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatDigit : MonoBehaviour
{
    [SerializeField] private Sprite[] sprites;
    private Image digit;

    // Start is called before the first frame update
    void Start()
    {
        //digit = GetComponent<Image>();
    }


    public void UpdateDigit(int dig)
    {
        Debug.Log("rendering digit: " + dig);

        this.GetComponent<Image>().sprite = sprites[dig];

        Debug.Log("render complete: " + dig);
    }
}
