using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game_menu : MonoBehaviour
{
    [SerializeField]
    GameObject manu_panel;

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
        if(manu_panel.activeSelf == true)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }


    public void Exit_button()
    {
        SceneManager.LoadScene("menu");
    }
}
