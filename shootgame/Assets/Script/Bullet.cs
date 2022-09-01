using UnityEngine;
using UnityEngine.Pool;

public class Bullet : MonoBehaviour
{

    [SerializeField] float speed = 1.0f;

    //오브젝트 자체에서 어떤 pool에 들어가야하는지 선언해주는 과정입니다.
    private IObjectPool<Bullet> lazerPool;
   
    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        //게임 오브젝트와 충돌하게 메모리 풀에 반환되는 함수
        lazerPool.Release(this);

    }

    public void SetPool(IObjectPool<Bullet> pool)
    {
        lazerPool = pool;
    }
}
