using UnityEngine;
using UnityEngine.UI;

public class GridButton : MonoBehaviour
{
    public Vector2Int gridPosition;
    private Image panelImage;
    private Image attackAim;
    //private Image attackImage;
    public bool isAttackButton;
    public bool aimed;

    private void Start()
    {

        panelImage = transform.Find("Panel").GetComponent<Image>();
        SetTransparent(panelImage);
        attackAim = transform.Find("AttackAim").GetComponent<Image>();
        SetTransparent(attackAim);
        //attackImage = transform.Find("AttackImage").GetComponent<Image>();
        //SetTransparent(attackImage);
    }

    private void Update()
    {
        if (!isAttackButton)
        {
            CheckStatusPlayer();
        } 
        else
        {
            CheckStatusOpponent();
        }
       
    }

    public void CheckStatusPlayer()
    {
        if (InProx(FindObjectOfType<Ghost>().gridPosition))
        {
            SetVisible(panelImage);
        }
        else
        {
            SetTransparent(panelImage);
        }
    }

    public void CheckStatusOpponent()
    {
        if (AttackController.Instance.hasCenter == false)
        {
            SetTransparent(attackAim);
        }
        else if (AttackController.Instance.IsTileAttackPattern(gridPosition))
        {
            SetVisible(attackAim);
        }
        else
        {
            SetTransparent(attackAim);
        }
    }


    public void OnClick()
    {

        if (!isAttackButton)
        {
            movePlayer();
        }
        else
        {
            aimLock();
        }
        
    }

    private void movePlayer()
    {
        Vector3 worldPos = transform.position;
        worldPos.z = 0f;

        FindObjectOfType<Ghost>().MoveTo(worldPos, gridPosition);
    }

    private void aimLock()
    {
        AttackController.Instance.hasCenter = true;
        AttackController.Instance.center = gridPosition;
    }

    private void cancelAim()
    {
        AttackController.Instance.hasCenter = false;
    }

    private void executeAttack()
    {
        // play attack animation on this button.
    }


    private void SetVisible(Image img)
    {
        Color color = img.color;
        color.a =  1f;
        img.color = color;
    }

    private void SetTransparent(Image img)
    {
        Color color = img.color;
        color.a = 0f;
        img.color = color;
    }

    private bool InProx(Vector2Int g)
    {
        return Vector2Int.Distance(g, gridPosition) <= 1f;
    }

}
