using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTypeButton : MonoBehaviour
{

    [SerializeField] private int attackType;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        GameController.Instance.setActionAttackType(attackType);
        AttackController.Instance.hasCenter = true;
        GameController.Instance.UpdateAction();
    }
}
