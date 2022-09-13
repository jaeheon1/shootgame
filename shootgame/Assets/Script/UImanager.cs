using UnityEngine;
using UnityEngine.UI;

public class UImanager : MonoBehaviour
{

    [SerializeField] Text score;
    
    void Update()
    {
        score.text = "Kill:" + gamemanager.instance.score;


        // 게임 매니저 : 스코어 게임실행 정지 
        // UI 매니저 : 
    }


    //이 함수를 버튼에 등록할 때 게임 오브젝트 매개변수로 게임오브젝트를 등록할 수 있습니다. 
    //등록한 게임 오브젝트를 비활성화 수 있습니다.
    public void GameStart(GameObject mainMenu)
    {
        mainMenu.SetActive(false);

        Cursor.visible = false; //마우스커서 없애기

        Cursor.lockState = CursorLockMode.Locked; //마우스 락
    }
}
