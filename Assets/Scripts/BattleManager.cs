using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckActions(){
        // update opponent's numbers in PlayerOpponent script
        // compare player speeds to see who acts first
        // first, make the faster player act
        // wait for their action to finish (couroutine)
        // make the slower player act
    }

    public void UserAction(){
        // the attack or movement you have chosen
    }

    public void OpponentAction(){
        // compare the opponent's current position to their last position
        // if it has changed, it means they have moved, so no need to check attack
        // if not, it means they performed an attack, so check the attack
    }
}
