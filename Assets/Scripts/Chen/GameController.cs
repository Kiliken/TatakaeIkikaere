using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GridButton[] playerGridButtons;
    [SerializeField] private GridButton[] opponentGridButtons;

    public static GameController Instance;

    //the current executable action:
    //  no action :                 0
    //  move :                      1
    //  attack type selected:       2 
    //  attack location selected:   3
    public int actionMode = 0;

    public Vector2Int moveDestination;

    private Vector2Int attackCenter;
    private int attackType;

    private GridButton[,] playerButtons = new GridButton[3, 3];
    private GridButton[,] oppoButtons = new GridButton[3, 3];
    [SerializeField] private GameObject confirmB;
    [SerializeField] private GameObject backB;
    [SerializeField] private GameObject attackTypePanel;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        actionMode = 0;

        int count = 0;

        for (int py = 0; py < 3; py++)
        {
            for (int px = 0; px < 3; px++)
            {
                playerButtons[px, py] = playerGridButtons[count];
                count++;
            }

        }

        count = 0;
        for (int oy = 0; oy < 3; oy++)
        {
            for (int ox = 0; ox < 3; ox++)
            {
                oppoButtons[ox, oy] = opponentGridButtons[count];
                count++;
            }
        }

        //playerButtons[1, 0].movePlayer();
        
    }


    // Update is called once per frame
    void Update()
    {
        if (actionMode == 0)
        {
            confirmB.SetActive(false);
            backB.SetActive(false);
            setPlayerButtonsActive(true);
            setOpponentButtonsActive(false);
            attackTypePanel.SetActive(true);
        }
        else if (actionMode == 1)
        {

            confirmB.SetActive(true);
            confirmB.GetComponent<ConfirmButton>().notPressedObj.SetActive(true);
            backB.SetActive(true);
            backB.GetComponent<BackButton>().notPressedObj.SetActive(true);
            setPlayerButtonsActive(true);
            setOpponentButtonsActive(false);
            attackTypePanel.SetActive(false);
        }
        else if (actionMode == 2)
        {
            confirmB.SetActive(false);
            confirmB.GetComponent<ConfirmButton>().notPressedObj.SetActive(false);
            backB.SetActive(false);
            backB.GetComponent<BackButton>().notPressedObj.SetActive(false);
            setPlayerButtonsActive(false);
            setOpponentButtonsActive(true);
            attackTypePanel.SetActive(true);
        }
        else if (actionMode == 3)
        {
            confirmB.SetActive(true);
            confirmB.GetComponent<ConfirmButton>().notPressedObj.SetActive(true);
            backB.SetActive(true);
            backB.GetComponent<BackButton>().notPressedObj.SetActive(true);
            setPlayerButtonsActive(false);
            setOpponentButtonsActive(true);
            attackTypePanel.SetActive(false);
        }
    }

    // Sets Action Mode to moving(1)
    public void setActionMove(Vector2Int destination)
    {
        actionMode = 1;
        moveDestination = destination; 
    }

    public void setActionAttackType(int attackType)
    {
        actionMode = 2;
        AttackController.Instance.currentAttackType = attackType;
    }

    public void setActionAttackLocation(Vector2Int center)
    {
        actionMode = 3;
    }

    public void executeCurrentAction()
    {
        if(actionMode == 1)
        {
            playerButtons[moveDestination.x, moveDestination.y].movePlayer();
            actionMode = 0;
        } 
        else if (actionMode == 3)
        {
            
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    if (AttackController.Instance.IsTileAttackPattern(new Vector2Int(x , y)))
                    {
                        oppoButtons[x, y].gameObject.GetComponent<GridButton>().executeAttack();
                    }
                        
                        
                       
                }
            }

            AttackController.Instance.ExecuteAttack();

        }
        
        
        
    }
    
   
    public void resetMode()
    {
        for (int px = 0; px < 3; px++)
        {
            for (int py = 0; py < 3; py++)
            {
                oppoButtons[px, py].gameObject.transform.Find("AttackImage").gameObject.SetActive(false);
            }
        }
        setOpponentButtonsActive(false);
        actionMode = 0;

    }
    public void back()
    {
        actionMode = 0;
        AttackController.Instance.center = new Vector2Int(1, 1);
        AttackController.Instance.hasCenter = false;
        
    }

    private void setPlayerButtonsActive(bool state) 
    {
        for (int px = 0; px < 3; px++)
        {
            for (int py = 0; py < 3; py++)
            {
                playerButtons[px, py].gameObject.SetActive(state);
            }
        }
    }

    private void setOpponentButtonsActive(bool state)
    {
        for (int px = 0; px < 3; px++)
        {
            for (int py = 0; py < 3; py++)
            {
                oppoButtons[px, py].gameObject.SetActive(state);
            }
        }
    }
}
