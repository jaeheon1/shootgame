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


        // ���� �Ŵ��� : ���ھ� ���ӽ��� ���� 
        // UI �Ŵ��� : 
    }


    //�� �Լ��� ��ư�� ����� �� ���� ������Ʈ �Ű������� ���ӿ�����Ʈ�� ����� �� �ֽ��ϴ�. 
    //����� ���� ������Ʈ�� ��Ȱ��ȭ �� �ֽ��ϴ�.
    public void GameStart()
    {
        StartCoroutine(FadeIn(1));
        
        gamemanager.instance.state = true;



        Cursor.visible = false; //���콺Ŀ�� ���ֱ�
        Cursor.lockState = CursorLockMode.Locked; //���콺 ��

        //Time.unscaledDeltaTime :Ÿ�ӽ������� ������ ���� �ʴ� �ð��Դϴ�.
        //state =true �϶� �������� 
        //state=false �϶� ��������
    }
    //�Ű� ���� time�� FadeIn �Ǵ� �ð��� �����ϴ� �����Դϴ�.
    private IEnumerator FadeIn(float time)
    {
        Color color = fadePanel.color;

        //0~255 (0~1)������ ������ ��� �մϴ�.
        //�̹����� ���İ��� 0�� �Ǵ� ���� While ���� Ż���մϴ�.
        while(color.a>0f)
        {
            color.a -= Time.deltaTime / time;
            fadePanel.color = color;
            yield return null;
        }
        //�ڷ�ƾ �Լ��� �� �������� mainMenu �� ��Ȱ��ȭ�մϴ�.
        mainMenu.SetActive(false);
    }

}
//Time Scale�� 0���� �ϰ� �Ǹ� ����Ƽ ���� �ִ� �ð��� �� 0���� �������ϴ�.