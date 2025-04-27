using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EnemyButtonScript : MonoBehaviour, IPointerEnterHandler
{
    public Vector2Int gridPosition;
    private Image panelImage;


    // Start is called before the first frame update
    void Start()
    {
        panelImage = transform.Find("AttackPanel").GetComponent<Image>();
        SetPanelTransparent();
    }

    // Update is called once per frame
    void Update()
    {
        CheckStatus();
    }

    public void CheckStatus()
    {
        if (AttackController.Instance.IsTileAttackPattern(gridPosition))
        {
            SetPanelVisible();
        }
        else
        {
            SetPanelTransparent();
        }
    }

    public void OnClick()
    {
        //AttackController.Instance.ExecuteAttackAt(gridPos);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        AttackController.Instance.center = gridPosition;
    }

    private void SetPanelTransparent()
    {
        Color color = panelImage.color;
        color.a = 0f;
        panelImage.color = color;
    }

    private void SetPanelVisible()
    {
        Color color = panelImage.color;
        color.a = 0.25f;
        panelImage.color = color;
    }
}
