using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{

    [SerializeField] float speed = 1.0f;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked; //마우스 락
    }

    
    void Update()
    {
        float x= Input.GetAxis("Mouse X");//모바일도 되고 pc도 됩니다.
        float y = Input.GetAxis("Mouse Y");

        Vector3 direction = new Vector3(x, 0, y);

        transform.Translate(direction.normalized * speed * Time.deltaTime);


        //게임 오브젝트의 위치를 스크린 공간으로 변환합니다.
        Vector3 position = Camera.main.WorldToViewportPoint(transform.position);

        //좌표 정보를 기준으로 조건문을 작성합니다.
        if (position.x < 0f) position.x = 0.0f;
        if (position.x > 1f) position.x = 1.0f;
        if (position.y < 0f) position.y = 0.0f;
        if (position.y > 1f) position.y = 1.0f;

        transform.position = Camera.main.ViewportToWorldPoint(position);


    }
}
