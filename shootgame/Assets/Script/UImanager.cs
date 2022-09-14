using UnityEngine;
using UnityEngine.UI;

public class UImanager : MonoBehaviour
{

    [SerializeField] Text score;

    private void Start()
    {
        
    }
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
        gamemanager.instance.state = true;
        Cursor.visible = false; //���콺Ŀ�� ���ֱ�

        Cursor.lockState = CursorLockMode.Locked; //���콺 ��

        //Time.unscaledDeltaTime :Ÿ�ӽ������� ������ ���� �ʴ� �ð��Դϴ�.
        //state =true �϶� �������� 
        //state=false �϶� ��������
    }
}
//Time Scale�� 0���� �ϰ� �Ǹ� ����Ƽ ���� �ִ� �ð��� �� 0���� �������ϴ�.