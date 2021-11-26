using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game_menu : MonoBehaviour
{
    [SerializeField]
    GameObject manu_panel;

    GameObject player_camera;

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
