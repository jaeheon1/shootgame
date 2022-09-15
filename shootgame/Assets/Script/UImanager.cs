using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UImanager : MonoBehaviour
{

    [SerializeField] Text score;
    [SerializeField] Image fadePanel;
    [SerializeField] GameObject mainMenu;
 
    void Update()
    {
        score.text = "Kill:" + gamemanager.instance.score;


        // 게임 매니저 : 스코어 게임실행 정지 
        // UI 매니저 : 
    }


    //이 함수를 버튼에 등록할 때 게임 오브젝트 매개변수로 게임오브젝트를 등록할 수 있습니다. 
    //등록한 게임 오브젝트를 비활성화 수 있습니다.
    public void GameStart()
    {
        StartCoroutine(FadeIn(1));
        
        gamemanager.instance.state = true;



        Cursor.visible = false; //마우스커서 없애기
        Cursor.lockState = CursorLockMode.Locked; //마우스 락

        //Time.unscaledDeltaTime :타임스케일의 영향을 받지 않는 시간입니다.
        //state =true 일때 게임진행 
        //state=false 일때 게임정지
    }
    //매개 변수 time은 FadeIn 되는 시간을 조절하는 변수입니다.
    private IEnumerator FadeIn(float time)
    {
        Color color = fadePanel.color;

        //0~255 (0~1)사이의 비율로 계산 합니다.
        //이미지의 알파값이 0이 되는 순간 While 문을 탈출합니다.
        while(color.a>0f)
        {
            color.a -= Time.deltaTime / time;
            fadePanel.color = color;
            yield return null;
        }
        //코루틴 함수가 다 끝났을때 mainMenu 를 비활성화합니다.
        mainMenu.SetActive(false);
    }

}
//Time Scale을 0을로 하게 되면 유니티 내에 있는 시간이 다 0으로 정해집니다.