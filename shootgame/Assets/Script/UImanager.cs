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


        // ���� �Ŵ��� : ���ھ� ���ӽ��� ���� 
        // UI �Ŵ��� : 
    }
}
