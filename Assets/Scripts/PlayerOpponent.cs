using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOpponent : Player
{
    public Vector2Int lastPosition = new Vector2Int(1,1);
    void Awake()
    {
        // for checking the player script from the beginning
        // if a player opponent script already exists (from the title scene), destroy this object.
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
