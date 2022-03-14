using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
    

    GameObject player_camera;
    GameObject mouse_cursor_hide;
    GameObject google_Ads;

    private void Start()
    {
        player_camera = GameObject.Find("MainCamera");
        mouse_cursor_hide = GameObject.Find("GameManager");
        google_Ads = GameObject.Find("Google_Ads");
    }
    private void Update()
    {
        
    }

    void finish_ilne()
    {

    }

    public void HP_Bar_UI()
    {
        float HP_data;
        GameObject HP = GameObject.Find("Player");
        HP_data = HP.GetComponent<player>().player_hp;
        HP_Bar.fillAmount = HP_data / MaxHP;
    }

    public void Stamina_Bar_UI()
    {
        float ST_data;
        GameObject Stamina = GameObject.Find("Player");
        ST_data = Stamina.GetComponent<player>().player_Stamina;
        Stamina_Bar.fillAmount = ST_data / MaxST;
    }

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

    public void Continue_buuton()
    {
        Game_Over_Panel.SetActive(false);
        google_Ads.GetComponent<Goolge_Ads>().AdStart();
    }

    public void Exit_button()
    {
        Time.timeScale = 1;
        mouse_cursor_hide.GetComponent<GameManager>().cursor_onoff(false);
        SceneManager.LoadScene("menu");
        Cursor.visible = true;
    }

}
