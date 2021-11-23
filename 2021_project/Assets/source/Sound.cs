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
        //스위치를 사용하여 현재 씬에 맞춰서 배경음악 변경할수 있게 코드 설정
        switch (SceneManager.GetActiveScene().name)
        {
            case "menu":
                //사운드소스에 배경음악 저장한 배열 번호 순으로 부르기
                Play_BGMClip.clip = BGM_Sound[0];
                //BGM 사운드 시작
                Play_BGMClip.Play();
                break;
            case "SampleScene":
                //사운드소스에 배경음악 저장한 배열 번호 순으로 부르기
                Play_BGMClip.clip = BGM_Sound[1];
                //BGM 사운드 시작
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
