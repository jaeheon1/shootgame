using UnityEngine;
using UnityEngine.Pool;


public class Controller : MonoBehaviour
{

    [SerializeField] float speed = 1.0f;
    [SerializeField] Transform centerMuzzle;
    [SerializeField] Bullet lazerPrefab;
    [SerializeField] GameObject pet;
    //메모리 풀로 사용할 게임 오브젝트
    private IObjectPool<Bullet> lazerPool;
    //메모리 풀로 사용할 클래스 

    private void Awake()
    {
        // 1,(생성하는 함수) 2, 활성화 하는 함수 3.비활성화 하는 함수  4. 게임 오브젝트를 파괴하는 함수 5. maxsize 메모리에 저장하고 싶은 갯수 
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
        //게임매니저에 있는 state 변수가 false라면 함수를 종료시킵니다.
        if (gamemanager.instance.state == false) return;

        float x= Input.GetAxis("Mouse X");//모바일도 되고 pc도 됩니다.

        //Gamemanager.instance.dragon.이 0 이면 펫을 아직 구매하지 앟은 상태 .
        //Gamemanager.instance.dragon.이 1 이면 펫을 아직 구매 상태
       

        if (gamemanager.instance.dragon >=1)
        {
            pet.SetActive(true);
        }


        Vector3 direction = new Vector3(x,0, 0);

        transform.Translate(direction.normalized * speed * Time.deltaTime);


        //게임 오브젝트의 위치를 스크린 공간으로 변환합니다.
        Vector3 position = Camera.main.WorldToViewportPoint(transform.position);

        //좌표 정보를 기준으로 조건문을 작성합니다.
        if (position.x < 0.1f) position.x = 0.1f;
        if (position.x > 0.9f) position.x = 0.9f;
       

        transform.position = Camera.main.ViewportToWorldPoint(position);


    }
    //1게임 오브젝트를 생성하는 함수. 
    public Bullet LayerCreate()
    {
        Bullet bullet = Instantiate(lazerPrefab).GetComponent<Bullet>();
        bullet.SetPool(lazerPool);
        return bullet;
    }

   // 2 활성화 하는 함수
   // get 이 실행 될 때 실행되는 함수
   public void LazerGet(Bullet lazer)
    {
        lazer.gameObject.SetActive(true);
    }
    //3게임 오브젝트를 비활성화 하는 함수 
    public void ReleaseLazer(Bullet lazer)
    {
        lazer.gameObject.SetActive(false);
    }    

    //4게임 오브젝트를 파괴하는 함수
    public void Destroylazer(Bullet lazer)
    {
        Destroy(lazer.gameObject);
    }

}
