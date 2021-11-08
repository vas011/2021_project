using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sound : MonoBehaviour
{
    [SerializeField]
    AudioClip[] BGM_Sound;    
    [SerializeField]
    AudioClip[] SFX_sound;

    private AudioSource Play_BGMClip;
    private AudioSource Player_Cilp;

    void Play_BGM()
    {
        //����ġ�� ����Ͽ� ���� ���� ���缭 ������� �����Ҽ� �ְ� �ڵ� ����
        switch (SceneManager.GetActiveScene().name)
        {
            case "menu":
                //����ҽ��� ������� ������ �迭 ��ȣ ������ �θ���
                Play_BGMClip.clip = BGM_Sound[0];
                //BGM ���� ����
                Play_BGMClip.Play();
                break;
            case "SampleScene":
                //����ҽ��� ������� ������ �迭 ��ȣ ������ �θ���
                Play_BGMClip.clip = BGM_Sound[1];
                //BGM ���� ����
                Play_BGMClip.Play();
                break;
            default:
                break;
        }

    }
    public void Player_SFX_Play()
    {
        Player_Cilp.clip = SFX_sound[0];
        Player_Cilp.Play();
    }

    // Start is called before the first frame update
    void Start()
    {
        Play_BGMClip = GetComponent<AudioSource>();
        Player_Cilp = GetComponent<AudioSource>();
        Play_BGM();
    }

    // Update is called once per frame
    void Update()
    {
    }
}
