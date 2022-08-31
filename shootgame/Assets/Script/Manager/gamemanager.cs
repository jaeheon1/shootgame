using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamemanager : MonoBehaviour
{

    public static gamemanager instance;
    public int score;
 
    void Start()
    {
        if(instance==null)
        {
            instance = this;
        }
    }

   
    
}
