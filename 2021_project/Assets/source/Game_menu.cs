using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
// 인게임 UI 기능들
public class Game_menu : MonoBehaviour
{
    float MaxHP = 100;
    float MaxST = 100;

    [SerializeField]
    GameObject manu_panel;
    [SerializeField]
    GameObject Game_Over_Panel;

    [SerializeField]
    Image HP_Bar;
    [SerializeField]
    Image Stamina_Bar;
    [SerializeField]
    Image finish_direction;

    GameObject gameManager;
    GameObject player_camera;
    GameObject mouse_cursor_hide;
    GameObject google_Ads;

    private void Start()
    {
        player_camera = GameObject.Find("MainCamera");
        mouse_cursor_hide = GameObject.Find("GameManager");
        google_Ads = GameObject.Find("Google_Ads");
        gameManager = GameObject.Find("GameManager");
    }
    private void Update()
    {
        
    }

    void finish_ilne()
    {

    }

    //HP 바
    public void HP_Bar_UI()
    {
        float HP_data;
        GameObject HP = GameObject.Find("Player");
        HP_data = HP.GetComponent<player>().player_hp;
        HP_Bar.fillAmount = HP_data / MaxHP;
    }
    //스테미너 바
    public void Stamina_Bar_UI()
    {
        float ST_data;
        GameObject Stamina = GameObject.Find("Player");
        ST_data = Stamina.GetComponent<player>().player_Stamina;
        Stamina_Bar.fillAmount = ST_data / MaxST;
    }
    //일시 정지 및 메뉴 버튼(현재는 오브젝트 비활성화 해둠)
    public void menu_onoff()
    {
        
        if(manu_panel.activeSelf == false)
        {
            manu_panel.SetActive(true);
            mouse_cursor_hide.GetComponent<GameManager>().cursor_onoff(true);
        }
        else
        {
            manu_panel.SetActive(false);
            mouse_cursor_hide.GetComponent<GameManager>().cursor_onoff(false);
        }
    }
    //게임 일시정지 패널
    public void Game_paues()
    {
        if (manu_panel.activeSelf == true)
        {
            Time.timeScale = 0;
            player_camera.GetComponent<Player_Camera>().paues_trigger = true;
            //게임 매니저 안에 마우스 숨기기 기능 불러오기
            mouse_cursor_hide.GetComponent<GameManager>().cursor_onoff(true);
        }
        else
        {
            Time.timeScale = 1;
            player_camera.GetComponent<Player_Camera>().paues_trigger = false;
            mouse_cursor_hide.GetComponent<GameManager>().cursor_onoff(false);
        }
    }
    //게임 오버 패널
    public void Game_Over()
    {
        Game_Over_Panel.SetActive(true);
    }
    //이어하기 버튼
    public void Continue_buuton()
    {
        Game_Over_Panel.SetActive(false);
        google_Ads.GetComponent<Goolge_Ads>().AdStart();
        gameManager.GetComponent<GameManager>().Game_ReStart();
    }
    //나가기 버튼
    public void Exit_button()
    {
        Time.timeScale = 1;
        mouse_cursor_hide.GetComponent<GameManager>().cursor_onoff(false);
        SceneManager.LoadScene("Lobby");
        Cursor.visible = true;
    }

}
