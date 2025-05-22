using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridButton : MonoBehaviour
{
    public Vector2Int gridPosition;
    private Image panelImage;
    private Image destination;
    private Image attackAim;
    private Image centerAttackAim;
    private Image attackImage;

    public bool isAttackButton;
    public bool aimed;
    public bool isCenter;
    private Vector3 worldPos;

    private void Start()
    {

        

        panelImage = transform.Find("Panel").GetComponent<Image>();
        SetTransparent(panelImage);
        destination = transform.Find("DestinationPointer").GetComponent<Image>();
        SetTransparent(destination);
        attackAim = transform.Find("AttackAim").GetComponent<Image>();
        SetTransparent(attackAim);
        centerAttackAim = transform.Find("AttackAimCenter").GetComponent<Image>();
        SetTransparent(centerAttackAim);


        attackImage = transform.Find("AttackImage").GetComponent<Image>();
        SetTransparent(attackImage);
        attackImage.gameObject.SetActive(false);
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
        if (GameController.Instance.actionMode == 0)
        {
            SetTransparent(destination);
            if (InProx(FindObjectOfType<Ghost>().gridPosition))
            {
                SetVisible(panelImage);
            }
            else
            {
                SetTransparent(panelImage);
            }
        }
        else if (GameController.Instance.actionMode == 1)
        {
            if (GameController.Instance.player1des == gridPosition && InProx(FindObjectOfType<Ghost>().gridPosition))
            {
                SetVisible(destination);
                SetTransparent(panelImage);
            }
            else if (InProx(FindObjectOfType<Ghost>().gridPosition))
            {
                SetVisible(panelImage);
                SetTransparent(destination);
            }
            else
            {
                SetTransparent(panelImage);
                SetTransparent(destination);
            }
        }
        else if (GameController.Instance.actionMode == 3)
        {
            SetTransparent(panelImage);
            SetTransparent(destination);
        }


    }

    public void CheckStatusOpponent()
    {
        if (AttackController.Instance.hasCenter == false)
        {
            SetTransparent(attackAim);
            SetTransparent(centerAttackAim);
            //attackImage.gameObject.SetActive(false);

        }
        else if (AttackController.Instance.IsTileAttackPattern(gridPosition, GameController.Instance.player1CurAtkType) && AttackController.Instance.center == gridPosition)
        {
            SetVisible(centerAttackAim);
            SetTransparent(attackAim);



        }
        else if (AttackController.Instance.IsTileAttackPattern(gridPosition, GameController.Instance.player1CurAtkType))
        {
            SetVisible(attackAim);
            SetTransparent(centerAttackAim);

        }
        else
        {
            SetTransparent(attackAim);
            SetTransparent(centerAttackAim);
            //attackImage.gameObject.SetActive(false);
        }

    }


    public void OnClick()
    {

        if (!isAttackButton)
        {
            if (InProx(FindObjectOfType<Ghost>().gridPosition))
            {
                setDestination();
            }
        }
        else
        {
            aimLock();
        }
        GameController.Instance.UpdateAction();
    }

    private void setDestination()
    {
        GameController.Instance.setActionMove(gridPosition);

    }

    public void movePlayer()
    {
        worldPos = transform.position;
        worldPos.z = 0f;

        Debug.Log("enemy moved to " + gridPosition.x + "," + gridPosition.y);

        FindObjectOfType<Ghost>().MoveTo(worldPos, gridPosition);
    }

    public void moveEnemy()
    {
        //GameController.Instance.UpdateAction();
        
        worldPos = transform.position;
        worldPos.z = 0f;
        Debug.Log("enemy moved to " + gridPosition.x + "," + gridPosition.y);
        //Debug.Log("enemy moved to worldpos: " + worldPos.x + "," + worldPos.y);
        FindObjectOfType<EnemyGhost>().MoveTo(worldPos, gridPosition);
    }

    private void aimLock()
    {
        AttackController.Instance.hasCenter = true;
        AttackController.Instance.center = gridPosition;
        GameController.Instance.setActionAttackLocation(gridPosition);
    }

    private void cancelAim()
    {
        AttackController.Instance.hasCenter = false;
    }

    public void executeAttack()
    {
        if(GameController.Instance.actionMode == 2)
        {
            //if (AttackController.Instance.IsTileAttackPattern(gridPosition, AttackController.Instance.currentAttackType))
            //{
            //    Debug.Log("executed attack at " + gridPosition.x + "," + gridPosition.y + " with type " + AttackController.Instance.currentAttackType);
            //    SetTransparent(attackAim);
            //    SetTransparent(centerAttackAim);
            //    attackImage.gameObject.SetActive(true);
            //    SetVisible(attackImage);

            //}
            //else
            //{
            //    SetTransparent(attackAim);
            //    SetTransparent(centerAttackAim);
            //}
            //Debug.Log("executed attack at " + gridPosition.x + "," + gridPosition.y + " with type " + AttackController.Instance.currentAttackType);
            SetTransparent(attackAim);
            SetTransparent(centerAttackAim);
            attackImage.gameObject.SetActive(true);
            SetVisible(attackImage);
        }
        else if (GameController.Instance.actionMode == 3)
        {
            //if (AttackController.Instance.IsTileAttackPatternOppo(gridPosition, AttackController.Instance.p2attackType))
            //{
            //    Debug.Log("executed attack at " + gridPosition.x + "," + gridPosition.y + " with type " + AttackController.Instance.currentAttackType);
            //    SetTransparent(attackAim);
            //    SetTransparent(centerAttackAim);
            //    attackImage.gameObject.SetActive(true);
            //    SetVisible(attackImage);

            //}
            //else
            //{
            //    SetTransparent(attackAim);
            //    SetTransparent(centerAttackAim);
            //}
            //Debug.Log("executed attack at " + gridPosition.x + "," + gridPosition.y + " with type " + AttackController.Instance.currentAttackType);
            SetTransparent(attackAim);
            SetTransparent(centerAttackAim);
            attackImage.gameObject.SetActive(true);
            SetVisible(attackImage);
        }

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
        return Vector2Int.Distance(g, gridPosition) <= 1f && Vector2Int.Distance(g, gridPosition) > 0f;
    }

}
