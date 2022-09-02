using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamemanager : MonoBehaviour
{

    public static gamemanager instance;
    public int score;
 
 
    void Start()
    {
        //게임 데이터를 게임이 시작할때 불러옵니다.
        Load();
        if (instance==null)
        {
            instance = this;
        }
    }

    public void Save()
    {
        //PlayerPrefs.SetInt 정수값을 저장하는 함수 
        //KEy -VALUE 를 가지고 저장합니다.
        PlayerPrefs.SetInt("score", score);
    }   
    public void Load()
    {
        score = PlayerPrefs.GetInt("Score");
    }
    
}
