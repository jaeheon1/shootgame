using UnityEngine;
using UnityEngine.Pool;

public class Bullet : MonoBehaviour
{

    [SerializeField] float speed = 1.0f;

    //������Ʈ ��ü���� � pool�� �����ϴ��� �������ִ� �����Դϴ�.
    private IObjectPool<Bullet> lazerPool;
   
    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        //���� ������Ʈ�� �浹�ϰ� �޸� Ǯ�� ��ȯ�Ǵ� �Լ�
        lazerPool.Release(this);

    }

    public void SetPool(IObjectPool<Bullet> pool)
    {
        lazerPool = pool;
    }
}
