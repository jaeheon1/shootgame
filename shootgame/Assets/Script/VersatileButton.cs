using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VersatileButton : MonoBehaviour
{
   public void Purchase(int price)
    {
        //아이템 가격이 GameManager에 있는 score 보다 크다면 
        if(price >gamemanager.instance.score)
        {
            //아이템이 구매되지 않고 함수가 종료됩니다.
            return;
        }
        else if(price <=gamemanager.instance.score)
        {
            gamemanager.instance.score -= price;
            gamemanager.instance.dragon++;
        }

    }
    public void OpenWindow(GameObject window)
    {
        window.SetActive(true);
    }
    public void CloseWindow(GameObject window)
    {
        window.SetActive(false);
    }

}
