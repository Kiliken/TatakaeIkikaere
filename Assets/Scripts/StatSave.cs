using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatSave : MonoBehaviour
{
    public int maxHP;
    public int Atk;
    public int Speed;
    public int[] AtkTypes;


    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("StatSave");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
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
