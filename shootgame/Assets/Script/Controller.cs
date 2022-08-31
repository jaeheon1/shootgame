using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{

    [SerializeField] float speed = 1.0f;
    [SerializeField] Transform centerMuzzle;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked; //���콺 ��

        InvokeRepeating(nameof(LayerCreate), 0, 0.1f);
    }

    
    void Update()
    {
        float x= Input.GetAxis("Mouse X");//����ϵ� �ǰ� pc�� �˴ϴ�.
      

        Vector3 direction = new Vector3(x,0, 0);

        transform.Translate(direction.normalized * speed * Time.deltaTime);


        //���� ������Ʈ�� ��ġ�� ��ũ�� �������� ��ȯ�մϴ�.
        Vector3 position = Camera.main.WorldToViewportPoint(transform.position);

        //��ǥ ������ �������� ���ǹ��� �ۼ��մϴ�.
        if (position.x < 0.1f) position.x = 0.1f;
        if (position.x > 0.9f) position.x = 0.9f;
       

        transform.position = Camera.main.ViewportToWorldPoint(position);


    }

    public void LayerCreate()
    {
        Instantiate
            (
            Resources.Load<GameObject>("Layer"),
            centerMuzzle.position,
            Quaternion.identity

            );
    }


}
