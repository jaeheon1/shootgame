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
        transform.Translate(Vector3.down * Time.deltaTime); // 적 비행기 내려옴

        if(transform.position.y<=-4.5f||health<=0)
        {
            Destroy(gameObject);
        }

      

    }
    //게임 오브젝트가 화면 밖으로 벗어났을때 호출되는 함수
    //private void OnBecameInvisible()
    //{
    //    Destroy(gameObject);
    //}


    //게임 오브젝트와 충돌을 했을때 호출되는 함수
    private void OnTriggerEnter(Collider other)
    {
        //충돌한 게임 오브젝트의 태그가 Lazer라면 
        if(other.CompareTag("Layer"))
        {
          
            health -= other.GetComponent<Bullet>().attack;
            StartCoroutine(nameof(Damage));
        }
        //캐릭터라는 태그를 가진 게임 오브젝트가 충돌했을때 충돌 당한 게임 오브젝트가 파괴됩니다;
        if(other.CompareTag("Character"))
        {
            Destroy(other.gameObject);
        }
    }
        
    
    //게임 오브젝트가 파괴되었을때 호출되는 함수.
    private void OnDestroy()
    {
        //게임데이터를 저장합니다.
        gamemanager.instance.Save();
        gamemanager.instance.score += 100;
        SoundManager.instance.SoundStart(1);
        Instantiate(Resources.Load<GameObject>("Explosion"),//생성할 오브젝트 
            transform.position,//생성되는 게임 오브젝트의 위치
            Quaternion.identity);//Quaternion.identity : 회전을 하지 않겠다는 의미입니다.
            //메모리풀 : 반복적으로 생성되고 파괴되는 오브젝트만 메모리풀에 적재합니다.
    }

    private IEnumerator Damage()
    {
        enemysprite.material =flash;
        flash.color = new Color(1, 1, 1, 0.5f);

        yield return new WaitForSeconds(0.05f);

        enemysprite.material = enemyMaterial;
    }
}
