using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private SpriteRenderer enemysprite;
    private Material enemyMaterial;
    [SerializeField] Material flash;

    void Start()
    {
        enemysprite = GetComponent<SpriteRenderer>();
        enemyMaterial = enemysprite.material;

        flash = new Material(flash);

    }



   

    
    void Update()
    {
        //vector3.down=0,-1,0
        transform.Translate(Vector3.down * Time.deltaTime); // �� ����� ������

        if(transform.position.y<=-4.5f)
        {
            Destroy(gameObject);
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(nameof(Damage));
        }

    }
    //���� ������Ʈ�� ȭ�� ������ ������� ȣ��Ǵ� �Լ�
    //private void OnBecameInvisible()
    //{
    //    Destroy(gameObject);
    //}


    //���� ������Ʈ�� �浹�� ������ ȣ��Ǵ� �Լ�
    private void OnTriggerEnter(Collider other)
    {

        Destroy(gameObject);

    }


    //���� ������Ʈ�� �ı��Ǿ����� ȣ��Ǵ� �Լ�.
    private void OnDestroy()
    {
        Instantiate(Resources.Load<GameObject>("Explosion"),//������ ������Ʈ 
            transform.position,//�����Ǵ� ���� ������Ʈ�� ��ġ
            Quaternion.identity);//Quaternion.identity : ȸ���� ���� �ʰڴٴ� �ǹ��Դϴ�.
            //�޸�Ǯ : �ݺ������� �����ǰ� �ı��Ǵ� ������Ʈ�� �޸�Ǯ�� �����մϴ�.
    }

    private IEnumerator Damage()
    {
        enemysprite.material = flash;
        flash.color = new Color(1, 1, 1, 0.5f);

        yield return new WaitForSeconds(0.05f);

        enemysprite.material = enemyMaterial;
    }
}
