using UnityEngine.UI;
using UnityEngine;

public class UImanager : MonoBehaviour
{

    [SerializeField] Text score;
    void Start()
    {
        
    }

    
    void Update()
    {
        score.text = "Kill:" + gamemanager.instance.score;


        // 게임 매니저 : 스코어 게임실행 정지 
        // UI 매니저 : 
    }
}
