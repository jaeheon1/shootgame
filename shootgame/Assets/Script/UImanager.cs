using UnityEngine;
using UnityEngine.UI;

public class UImanager : MonoBehaviour
{

    [SerializeField] Text score;
 
    void Update()
    {
        score.text = "Kill:" + gamemanager.instance.score;


        // ���� �Ŵ��� : ���ھ� ���ӽ��� ���� 
        // UI �Ŵ��� : 
    }
}
