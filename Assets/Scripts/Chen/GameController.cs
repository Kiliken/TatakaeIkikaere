using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GridButton[] playerGridButtons;
    [SerializeField] private GridButton[] opponentGridButtons;
    [SerializeField] private AttackTypeButton[] attackTypeButtons;

    public static GameController Instance;

    //the current executable action:
    //  no action :                     0
    //  move :                          1
    //  attack type selected:           2
    //  player attacked, emeny attack   3
    public int actionMode = 0;

    public Vector2Int moveDestination;

    private Vector2Int attackCenter;
    private int attackType;

    private GridButton[,] playerButtons = new GridButton[3, 3];
    private GridButton[,] oppoButtons = new GridButton[3, 3];
    [SerializeField] private GameObject confirmB;
    [SerializeField] private GameObject backB;
    [SerializeField] private GameObject attackTypePanel;


    //player stats to be initialized through InitiateCharacter( player number, atk, hp, spd, types)
    //player 1 is always the player on this end, and player 2 is always the opponent
    public int player1maxHP;
    public int player2maxHP;
    public int player1curHP;
    public int player2curHP;
    public int player1Atk;
    public int player2Atk;
    public int player1Speed;
    public int player2Speed;
    public Vector2Int player1pos;
    public Vector2Int player2pos;
    public Vector2Int player1des;
    public Vector2Int player2des;
    public int[] player1AtkTypes;
    public int[] player2AtkTypes;
    public int player1CurAtkType;
    public int player2CurAtkType;
    
    // move : true / attack : false
    private bool player2CurMove;


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

        
        int[] array = { 1, 3, 4, 7};
        InitiateCharacter(1, 100, 100, 100, array);
        player2des = new Vector2Int(2, 1);
        player2CurMove = false;

        //playerButtons[1, 0].movePlayer();
        UpdateAction();
    }


    // Update is called after all actions
    public void UpdateAction()
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
            confirmB.SetActive(true);
            confirmB.GetComponent<ConfirmButton>().notPressedObj.SetActive(true);
            backB.SetActive(true);
            backB.GetComponent<BackButton>().notPressedObj.SetActive(true);
            setPlayerButtonsActive(false);
            setOpponentButtonsActive(true);
            attackTypePanel.SetActive(false);
        }
        else if (actionMode == 3)
        {
            confirmB.SetActive(false);
            confirmB.GetComponent<ConfirmButton>().notPressedObj.SetActive(false);
            backB.SetActive(false);
            backB.GetComponent<BackButton>().notPressedObj.SetActive(false);
            setPlayerButtonsActive(!player2CurMove);
            setOpponentButtonsActive(player2CurMove);
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
        actionMode = 2;
    }

    public void executeCurrentAction()
    {
        if(actionMode == 1)
        {
            playerButtons[moveDestination.x, moveDestination.y].movePlayer();
            resetMode();
        } 
        else if (actionMode == 2)
        {
            
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    if (AttackController.Instance.IsTileAttackPattern(new Vector2Int(x , y), AttackController.Instance.currentAttackType))
                    {
                        oppoButtons[x, y].gameObject.GetComponent<GridButton>().executeAttack();
                        Debug.Log("executed attack at " + x + "," + y);
                    }
                        
                        
                       
                }
            }

            AttackController.Instance.ExecuteAttack();

        }
        else if (actionMode == 3)
        {

            if (player2CurMove)
            {
                oppoButtons[player2des.x, player2des.y].moveEnemy();
                resetMode();
            }
            else if (!player2CurMove)
            {
                for (int x = 0; x < 3; x++)
                {
                    for (int y = 0; y < 3; y++)
                    {
                        playerButtons[x, y].gameObject.GetComponent<GridButton>().executeAttack();
                    }
                }
            }
            
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

        if (actionMode == 3)
        {
            for (int px = 0; px < 3; px++)
            {
                for (int py = 0; py < 3; py++)
                {
                    playerButtons[px, py].gameObject.transform.Find("AttackImage").gameObject.SetActive(false);

                }
            }


            actionMode = 0;
            UpdateAction();

        }
        else if (actionMode == 1 || actionMode == 2)
        {
            actionMode = 3;
            UpdateAction();
            executeCurrentAction();
            

        }
        

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


    public void InitiateCharacter(int playerNum, int maxHP, int atk, int spd, int[] types) { 
        if(playerNum == 1)
        {
            player1maxHP = maxHP;
            player1curHP = maxHP;
            player1Atk = atk;
            player1Speed = spd;
            int index = 0;
            player1AtkTypes = new int[4];
            foreach (int n in types)
            {
                player1AtkTypes[index] = n;
                index++;
            }

            for(int i = 0; i < 4; i++)
            {
                attackTypeButtons[i].SetAttackType(player1AtkTypes[i]);
            }

        }
        else if(playerNum == 2)
        {
            player2maxHP = maxHP;
            player2curHP = maxHP;
            player2Atk = atk;
            player2Speed = spd;
            int index = 0;
            foreach (int n in types)
            {
                player1AtkTypes[index] = n;
                index++;
            }
        }
        

    }

}
