using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamemanager : MonoBehaviour
{

    public static gamemanager instance;
    public int score;
    //bool 변수는 초기화를 하지 않으면 false 값이 자동으로 들어갑니다.
    public bool state;


    private void Awake()
    {
        //Start 함수 이전에 시작이 됩니다.
        //게임 데이터를 게임이 시작할때 불러옵니다.
        
        if (instance == null)
        {
            instance = this;
        }
        Load();
    }

  

    public void Save()
    {
        //PlayerPrefs.SetInt 정수값을 저장하는 함수 
        //KEy -VALUE 를 가지고 저장합니다.
        PlayerPrefs.SetInt("score", score);
    }   
    public void Load()
    {
        score = PlayerPrefs.GetInt("score");
    }
    
}
