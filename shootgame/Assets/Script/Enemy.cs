using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    void Start()
    {
        
    }

    
    void Update()
    {
        //vector3.down=0,-1,0
        transform.Translate(Vector3.down * Time.deltaTime); // 적 비행기 내려옴
    }
    //게임 오브젝트가 화면 밖으로 벗어났을때 호출되는 함수
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }


    //게임 오브젝트와 충돌을 했을때 호출되는 함수
    private void OnTriggerEnter(Collider other)
    {

        Destroy(gameObject);

    }


    //게임 오브젝트가 파괴되었을때 호출되는 함수.
    private void OnDestroy()
    {
        Instantiate(Resources.Load<GameObject>("Explosion"),//생성할 오브젝트 
            transform.position,//생성되는 게임 오브젝트의 위치
            Quaternion.identity);//Quaternion.identity : 회전을 하지 않겠다는 의미입니다.
            //메모리풀 : 반복적으로 생성되고 파괴되는 오브젝트만 메모리풀에 적재합니다.
    }

}
