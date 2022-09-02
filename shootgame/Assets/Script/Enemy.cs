using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private SpriteRenderer enemysprite;
    private Material enemyMaterial;
    [SerializeField] Material flash;
    [SerializeField] int health = 100;
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

        if(transform.position.y<=-4.5f||health<=0)
        {
            Destroy(gameObject);
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
        //�浹�� ���� ������Ʈ�� �±װ� Lazer��� 
        if(other.CompareTag("Layer"))
        {
          
            health -= other.GetComponent<Bullet>().attack;
            StartCoroutine(nameof(Damage));
        }
        //ĳ���Ͷ�� �±׸� ���� ���� ������Ʈ�� �浹������ �浹 ���� ���� ������Ʈ�� �ı��˴ϴ�;
        if(other.CompareTag("Character"))
        {
            Destroy(other.gameObject);
        }
    }
        
    
    //���� ������Ʈ�� �ı��Ǿ����� ȣ��Ǵ� �Լ�.
    private void OnDestroy()
    {
        //���ӵ����͸� �����մϴ�.
        gamemanager.instance.Save();
        gamemanager.instance.score += 100;
        SoundManager.instance.SoundStart(1);
        Instantiate(Resources.Load<GameObject>("Explosion"),//������ ������Ʈ 
            transform.position,//�����Ǵ� ���� ������Ʈ�� ��ġ
            Quaternion.identity);//Quaternion.identity : ȸ���� ���� �ʰڴٴ� �ǹ��Դϴ�.
            //�޸�Ǯ : �ݺ������� �����ǰ� �ı��Ǵ� ������Ʈ�� �޸�Ǯ�� �����մϴ�.
    }

    private IEnumerator Damage()
    {
        enemysprite.material =flash;
        flash.color = new Color(1, 1, 1, 0.5f);

        yield return new WaitForSeconds(0.05f);

        enemysprite.material = enemyMaterial;
    }
}
