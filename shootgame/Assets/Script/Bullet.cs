using UnityEngine;
using UnityEngine.Pool;

public class Bullet : MonoBehaviour
{

    [SerializeField] float speed = 1.0f;
    public int attack = 20;
    //������Ʈ ��ü���� � pool�� �����ϴ��� �������ִ� �����Դϴ�.
    private IObjectPool<Bullet> lazerPool;
   
    void Update()
    {
        if (gamemanager.instance.state == false) return;
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
