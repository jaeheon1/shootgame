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
        transform.Translate(Vector3.forward * Time.deltaTime); // �� ����� ������
    }
    //���� ������Ʈ�� ȭ�� ������ ������� ȣ��Ǵ� �Լ�
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
