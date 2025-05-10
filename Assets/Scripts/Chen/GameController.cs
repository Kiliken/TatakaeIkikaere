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

    public Vector2Int moveDestination;

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
        moveDestination = destination; 
    }

    public void setActionAttack(Vector2Int center, int attackType)
    {
        actionMode = 2;
    }

    public void executeCurrentAction()
    {
        if(actionMode == 1)
        {
            playerButtons[moveDestination.x, moveDestination.y].movePlayer();
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
