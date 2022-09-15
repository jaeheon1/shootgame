using UnityEngine;
using UnityEngine.Pool;


public class Controller : MonoBehaviour
{

    [SerializeField] float speed = 1.0f;
    [SerializeField] Transform centerMuzzle;
    [SerializeField] Bullet lazerPrefab;
    [SerializeField] GameObject pet;
    //�޸� Ǯ�� ����� ���� ������Ʈ
    private IObjectPool<Bullet> lazerPool;
    //�޸� Ǯ�� ����� Ŭ���� 

    private void Awake()
    {
        // 1,(�����ϴ� �Լ�) 2, Ȱ��ȭ �ϴ� �Լ� 3.��Ȱ��ȭ �ϴ� �Լ�  4. ���� ������Ʈ�� �ı��ϴ� �Լ� 5. maxsize �޸𸮿� �����ϰ� ���� ���� 
        lazerPool = new ObjectPool<Bullet>(LayerCreate,LazerGet,ReleaseLazer,Destroylazer,maxSize:20);
    }
    void Start()
    {
        

        InvokeRepeating(nameof(Infiitylazer), 0, 0.1f);
    }
    public void Infiitylazer()
    {
        if (gamemanager.instance.state == false) return;
        SoundManager.instance.SoundStart(0);
        var bullet = lazerPool.Get();
        bullet.transform.position = centerMuzzle.transform.position;
    }
    
    void Update()
    {
        //���ӸŴ����� �ִ� state ������ false��� �Լ��� �����ŵ�ϴ�.
        if (gamemanager.instance.state == false) return;

        float x= Input.GetAxis("Mouse X");//����ϵ� �ǰ� pc�� �˴ϴ�.

        //Gamemanager.instance.dragon.�� 0 �̸� ���� ���� �������� ���� ���� .
        //Gamemanager.instance.dragon.�� 1 �̸� ���� ���� ���� ����
       

        if (gamemanager.instance.dragon >=1)
        {
            pet.SetActive(true);
        }


        Vector3 direction = new Vector3(x,0, 0);

        transform.Translate(direction.normalized * speed * Time.deltaTime);


        //���� ������Ʈ�� ��ġ�� ��ũ�� �������� ��ȯ�մϴ�.
        Vector3 position = Camera.main.WorldToViewportPoint(transform.position);

        //��ǥ ������ �������� ���ǹ��� �ۼ��մϴ�.
        if (position.x < 0.1f) position.x = 0.1f;
        if (position.x > 0.9f) position.x = 0.9f;
       

        transform.position = Camera.main.ViewportToWorldPoint(position);


    }
    //1���� ������Ʈ�� �����ϴ� �Լ�. 
    public Bullet LayerCreate()
    {
        Bullet bullet = Instantiate(lazerPrefab).GetComponent<Bullet>();
        bullet.SetPool(lazerPool);
        return bullet;
    }

   // 2 Ȱ��ȭ �ϴ� �Լ�
   // get �� ���� �� �� ����Ǵ� �Լ�
   public void LazerGet(Bullet lazer)
    {
        lazer.gameObject.SetActive(true);
    }
    //3���� ������Ʈ�� ��Ȱ��ȭ �ϴ� �Լ� 
    public void ReleaseLazer(Bullet lazer)
    {
        lazer.gameObject.SetActive(false);
    }    

    //4���� ������Ʈ�� �ı��ϴ� �Լ�
    public void Destroylazer(Bullet lazer)
    {
        Destroy(lazer.gameObject);
    }

}
