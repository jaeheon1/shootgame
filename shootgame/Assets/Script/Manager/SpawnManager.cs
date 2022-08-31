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


        //성능 - 1. 코루팅 , 2 update invokerepeating()
        //지정된 시간 후에 함수를 호출하는 함수입니다.
        //InvokeReapeating: 지정된 시간 후에 함수를 호출하고 몇 초 마다 반복 실행하는 함수 입니다. 
        InvokeRepeating(nameof(CreaterInfinite), 0,5);
        //5초뒤에 5초 마다 반복 실행 됩니다.
        //5초 마다 나오게 됩니다.
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

    //게임오브젝트를(eneemy) 생성하는 함수
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
