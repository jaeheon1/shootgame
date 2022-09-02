using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    private AudioSource audioSource;
    [SerializeField] AudioClip[] audioClip;
    void Start()
    {

        if(instance==null)
        {
            instance = this;
        }
        audioSource = GetComponent<AudioSource>();
    }

    //SoundStart() 함수는 매개변수 count 값에 따라 다른 사운드가 출력됩니다.
    public void SoundStart(int count)
    {
        // PlayOneShot() 함수는 오디오 클립에 따라 사운드가 한 번 호출 되는 함수 입니다. 
        audioSource.PlayOneShot(audioClip[count]);
    }
 
}
