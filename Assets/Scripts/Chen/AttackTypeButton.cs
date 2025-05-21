using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackTypeButton : MonoBehaviour
{

    public int attackType;
    private Image buttonImage;
    private Sprite[] sprites;
    private int spriteIndex;

    public void OnClick()
    {
        GameController.Instance.setActionAttackType(attackType);
        AttackController.Instance.hasCenter = true;
        GameController.Instance.UpdateAction();
    }

    public void SetAttackType(int t)
    {
        buttonImage = GetComponent<Image>();
        attackType = t;
        spriteIndex = attackType - 1;
        sprites = Resources.LoadAll<Sprite>("Sprites/AttackTypeButtonSpritesheet");
        //foreach (var s in sprites)
        //{
        //    Debug.Log("Loaded sprite: " + s.name);
        //}
        buttonImage.sprite = sprites[spriteIndex];
    }
}
