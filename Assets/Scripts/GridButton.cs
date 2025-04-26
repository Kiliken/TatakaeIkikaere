using UnityEngine;
using UnityEngine.UI;

public class GridButton : MonoBehaviour
{
    public Vector2Int gridPosition;
    //public GameObject panelPrefab;
    //public Transform parentTransform;
    private Image panelImage;

    private void Start()
    {
        //GameObject panel = Instantiate(panelPrefab, parentTransform);
        //panel.name = "Panel";
        panelImage = transform.Find("Panel").GetComponent<Image>();
        SetPanelTransparent();
    }

    private void Update()
    {
        CheckStatus();
    }

    public void CheckStatus()
    {
        if (InProx(FindObjectOfType<Ghost>().gridPosition))
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
        Vector3 worldPos = transform.position;
        worldPos.z = 0f;

        FindObjectOfType<Ghost>().MoveTo(worldPos, gridPosition);
        SetPanelTransparent();
    }


    private void SetPanelVisible()
    {
        Color color = panelImage.color;
        color.a =  0.25f;
        panelImage.color = color;
    }

    private void SetPanelTransparent()
    {
        Color color = panelImage.color;
        color.a = 0f;
        panelImage.color = color;
    }

    private bool InProx(Vector2Int g)
    {
        return Vector2Int.Distance(g, gridPosition) <= 1f;
    }

}
