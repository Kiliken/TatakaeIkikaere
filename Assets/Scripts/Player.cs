using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] protected int maxHP = 100;
    public int HP = 100;
    public int HPBonus = 0;
    public int AtkBonus = 0;
    public int SpeedBonus = 0;


    // Start is called before the first frame update
    void Start()
    {
        // if HP bonus is 2, add 20 HP to max HP
        HP = maxHP + (HPBonus * 10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
