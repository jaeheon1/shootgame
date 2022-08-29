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
        transform.Translate(Vector3.forward * Time.deltaTime); // 적 비행기 내려옴
    }
    //게임 오브젝트가 화면 밖으로 벗어났을때 호출되는 함수
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
