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
    Image HP_Bar;
    [SerializeField]
    Image Stamina_Bar;

    GameObject player_camera;

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
        }
        else
        {
            manu_panel.SetActive(false);
        }
    }

    public void Game_paues()
    {
        player_camera = GameObject.Find("MainCamera");
        if (manu_panel.activeSelf == true)
        {
            Time.timeScale = 0;
            player_camera.GetComponent<Player_Camera>().paues_trigger = true;
        }
        else
        {
            Time.timeScale = 1;
            player_camera.GetComponent<Player_Camera>().paues_trigger = false;
        }
    }

    public void Exit_button()
    {
        SceneManager.LoadScene("menu");
    }
}
