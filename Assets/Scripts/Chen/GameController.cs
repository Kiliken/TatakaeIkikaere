using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GridButton[] playerGridButtons;
    [SerializeField] private GridButton[] opponentGridButtons;

    public static GameController Instance;

    //the current executable action:
    //  no action :   0
    //  move :        1
    //  attack:       2 
    public int actionMode;

    private Vector2Int moveDestination;

    private Vector2Int attackCenter;
    private int attackType;

    private GridButton[,] playerButtons = new GridButton[3, 3];
    private GridButton[,] oppoButtons = new GridButton[3, 3];

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        actionMode = 0;

        int count = 0;

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                playerButtons[j, i] = playerGridButtons[count];
                count++;
            }
        }
        count = 0;
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                oppoButtons[j, i] = opponentGridButtons[count];
                count++;
            }
        }

        playerGridButtons[6].movePlayer();

    }

    // Update is called once per frame
    void Update()
    {
        if (actionMode == 0)
        {
        }
        else if (actionMode == 1)
        {

        }
        else if (actionMode == 2)
        {

        }
    }

    // Sets Action Mode to moving(1)
    public void setActionMove(Vector2Int destination)
    {
        actionMode = 1;
    }

    public void setActionAttack(Vector2Int center, int attackType)
    {
        actionMode = 2;
    }

    public void executeCurrentAction()
    {
        if(actionMode == 1)
        {

        } 
        else if (actionMode == 2)
        {
            
        }
    }
    
    public void back()
    {
        actionMode = 0;
    }
}
