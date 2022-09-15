using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamemanager : MonoBehaviour
{

    public static gamemanager instance;
    public int score;
    //bool ������ �ʱ�ȭ�� ���� ������ false ���� �ڵ����� ���ϴ�.
    public bool state;
    public int dragon;

    private void Awake()
    {
        //Start �Լ� ������ ������ �˴ϴ�.
        //���� �����͸� ������ �����Ҷ� �ҷ��ɴϴ�.
        
        if (instance == null)
        {
            instance = this;
        }
        Load();
    }

  

    public void Save()
    {
        //PlayerPrefs.SetInt �������� �����ϴ� �Լ� 
        //KEy -VALUE �� ������ �����մϴ�.
        PlayerPrefs.SetInt("score", score);

        PlayerPrefs.SetInt("Dragon", dragon);

    }
    public void Load()
    {
        score = PlayerPrefs.GetInt("score");
        dragon = PlayerPrefs.GetInt("Dragon");

    }


}
