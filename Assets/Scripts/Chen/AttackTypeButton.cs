using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackTypeButton : MonoBehaviour
{

    private int attackType;
    private Image buttonImage;
    private Sprite[] sprites;
    private int spriteIndex;

    // Start is called before the first frame update
    void Start()
    {
        buttonImage = GetComponent<Image>();
       

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

    public void SetAttackType(int t)
    {
        attackType = t;
        spriteIndex = attackType - 1;
        sprites = Resources.LoadAll<Sprite>("Sprites/AttackTypeButtonSpritesheet");
        buttonImage.sprite = sprites[spriteIndex];
    }
}
