using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    public bool resetComplete = false;


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
    public Vector2Int player1Center;
    public Vector2Int player2Center;
    public int player2CurAtkType;

    // move : true / attack : false
    private bool player1CurMove;
    private bool player2CurMove;
    public bool player1Faster;


    private void Awake()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;

        Instance = this;
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
        setPlayerButtonsActive(true);
        setOpponentButtonsActive(true);

        int[] array = { 1, 3, 4, 7 };
        InitiateCharacter(1, 100, 100, 100, array);
        InitiateCharacter(2, 100, 100, 200, array);
        player1Faster = player1Speed > player2Speed;
        player2CurMove = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        actionMode = 0;

        


        player2des = new Vector2Int(2, 1);
        player2Center = new Vector2Int(1,1);
        
        player2CurAtkType = 9;
        confirmB.SetActive(true);
        backB.SetActive(true);
        
        oppoButtons[2,2].moveEnemy();
        //playerButtons[1, 0].movePlayer();
        UpdateAction();
    }


    // Update is called after all actions
    public void UpdateAction()
    {
        //Debug.Log("update action");
        if (actionMode == 0)
        {
            resetComplete = false;
            Debug.Log($"action updated to 0000000000000000000000000000000000000000000000000");
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
            AttackController.Instance.hasCenter = false;
            setOpponentButtonsActive(player2CurMove);
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
        player1des = destination;
        player1CurMove = true;
    }

    public void setActionAttackType(int attackType)
    {
        actionMode = 2;
        AttackController.Instance.currentAttackType = attackType;
        player1CurMove = false;
    }

    public void setActionAttackLocation(Vector2Int center)
    {
        actionMode = 2;
    }

    public void executeCurrentAction()
    {
        if (player1Faster)
        {
            if (actionMode == 1)
            {
                StartCoroutine(p1move());
                resetMode();
            }
            else if (actionMode == 2)
            {
                for (int x = 0; x < 3; x++)
                {
                    for (int y = 0; y < 3; y++)
                    {
                        if (AttackController.Instance.IsTileAttackPattern(new Vector2Int(x, y), AttackController.Instance.currentAttackType))
                        {
                            oppoButtons[x, y].gameObject.GetComponent<GridButton>().executeAttack();
                            //Debug.Log("executed attack at " + x + "," + y +" at gc with type" + AttackController.Instance.currentAttackType);
                        }
                    }
                }
                AttackController.Instance.ExecuteAttack();
            }
        }
        else if (!player1Faster)
        {
            actionMode = 3;
            if (player2CurMove)
            {
                StartCoroutine(p2move());
                resetMode();
            }
            else if (!player2CurMove)
            {
                AttackController.Instance.p2center = player2Center;
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

    private void executeP1()
    {
        if (player1CurMove)
        {
            StartCoroutine(p1move());
            resetMode();
        }
        else if (!player1CurMove)
        {

            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    if (AttackController.Instance.IsTileAttackPattern(new Vector2Int(x, y), AttackController.Instance.currentAttackType))
                    {
                        oppoButtons[x, y].gameObject.GetComponent<GridButton>().executeAttack();
                        //Debug.Log("executed attack at " + x + "," + y + " at gc with type" + AttackController.Instance.currentAttackType);
                    }



                }
            }

            AttackController.Instance.ExecuteAttack();

        }
    }

    private void executeP2()
    {
        if (player2CurMove)
        {
            StartCoroutine(p2move());
            resetMode();
        }
        else if (!player2CurMove)
        {
            AttackController.Instance.p2center = player2Center;
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    playerButtons[x, y].gameObject.GetComponent<GridButton>().executeAttack();
                }
            }
        }
    }

    private IEnumerator p1move()
    {

        playerButtons[player1des.x, player1des.y].movePlayer();
        yield return new WaitForSeconds(1f);
        
    }
    private IEnumerator p2move()
    {       
        setOpponentButtonsActive(true);
        oppoButtons[player2des.x, player2des.y].moveEnemy();
        yield return new WaitForSeconds(1f);
        
        
    }



    
   
    public void resetMode()
    {
        //for (int px = 0; px < 3; px++)
        //{
        //    for (int py = 0; py < 3; py++)
        //    {
        //        playerButtons[px, py].gameObject.transform.Find("AttackImage").gameObject.SetActive(false);

        //    }
        //}
        //for (int px = 0; px < 3; px++)
        //{
        //    for (int py = 0; py < 3; py++)
        //    {
        //        oppoButtons[px, py].gameObject.transform.Find("AttackImage").gameObject.SetActive(false);

        //    }
        //}



        if (actionMode == 3)
        {
            if (!player1Faster)
            {
                for (int px = 0; px < 3; px++)
                {
                    for (int py = 0; py < 3; py++)
                    {
                        playerButtons[px, py].gameObject.transform.Find("AttackImage").gameObject.SetActive(false);

                    }
                }
                if (player1CurMove)
                {
                    actionMode = 1;
                }
                else
                {
                    actionMode = 2;
                }

                UpdateAction();
                executeP1();
            }
            else
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
        }
        else if (actionMode == 1 || actionMode == 2)
        {
            if (player1Faster)
            {
                for (int px = 0; px < 3; px++)
                {
                    for (int py = 0; py < 3; py++)
                    {
                        oppoButtons[px, py].gameObject.transform.Find("AttackImage").gameObject.SetActive(false);

                    }
                }
                
                actionMode = 3;
                UpdateAction();
                executeP2();
            }
            else
            {
                for (int px = 0; px < 3; px++)
                {
                    for (int py = 0; py < 3; py++)
                    {
                        oppoButtons[px, py].gameObject.transform.Find("AttackImage").gameObject.SetActive(false);

                    }
                }
                
                actionMode = 0;
                UpdateAction();
            }
        }
        

    }
    public void back()
    {
        actionMode = 0;
        AttackController.Instance.center = new Vector2Int(1, 1);
        AttackController.Instance.hasCenter = false;
        UpdateAction();
        
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
        Debug.Log("oppo buttons set active: " + state);
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
