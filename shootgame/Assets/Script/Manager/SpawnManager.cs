using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] Transform[] randomPosition;
    float timer;

    void Start()
    {
        CreaterInfinite();


        //���� - 1. �ڷ��� , 2 update invokerepeating()
        //������ �ð� �Ŀ� �Լ��� ȣ���ϴ� �Լ��Դϴ�.
        //InvokeReapeating: ������ �ð� �Ŀ� �Լ��� ȣ���ϰ� �� �� ���� �ݺ� �����ϴ� �Լ� �Դϴ�. 
        InvokeRepeating(nameof(CreaterInfinite), 0,5);
        //5�ʵڿ� 5�� ���� �ݺ� ���� �˴ϴ�.
        //5�� ���� ������ �˴ϴ�.
        InvokeRepeating(nameof(CreaterInfinite), 0, 5);
        InvokeRepeating(nameof(CreaterInfinite), 0, 5);
        InvokeRepeating(nameof(CreaterInfinite), 0, 5);


    }


    //void Update()
    //{

    //    timer += Time.deltaTime;
    //    if(timer>=2f)
    //    {
    //        CreaterInfinite();
    //        timer = 0;
    //    }
    //}

    //���ӿ�����Ʈ��(eneemy) �����ϴ� �Լ�
    public void CreaterInfinite()
    {
        Instantiate

            (
            Resources.Load<GameObject>("Enemy"),
            randomPosition[Random.Range(0,5)].position,
            Quaternion.identity
            
            );

    }
}
