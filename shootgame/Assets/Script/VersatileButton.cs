using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VersatileButton : MonoBehaviour
{
   public void Purchase(int price)
    {
        //������ ������ GameManager�� �ִ� score ���� ũ�ٸ� 
        if(price >gamemanager.instance.score)
        {
            //�������� ���ŵ��� �ʰ� �Լ��� ����˴ϴ�.
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
