using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Sound : MonoBehaviour
{
    [SerializeField]
    player player;

    [SerializeField]
    Scrollbar BG_bar;
    [SerializeField]
    Scrollbar SFX_bar;

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
        player.Player_sound.clip = SFX_sound[0];
        player.Player_sound.Play();
    }

    public void Set_BG_Sound()
    {
        Play_BGMClip.volume = BG_bar.value;
    }
    public void Set_SFX_Sound()
    {
        player.Player_sound.volume = SFX_bar.value;
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
