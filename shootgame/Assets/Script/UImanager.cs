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


    //�� �Լ��� ��ư�� ����� �� ���� ������Ʈ �Ű������� ���ӿ�����Ʈ�� ����� �� �ֽ��ϴ�. 
    //����� ���� ������Ʈ�� ��Ȱ��ȭ �� �ֽ��ϴ�.
    public void GameStart(GameObject mainMenu)
    {
        mainMenu.SetActive(false);

        Cursor.visible = false; //���콺Ŀ�� ���ֱ�

        Cursor.lockState = CursorLockMode.Locked; //���콺 ��
    }
}
