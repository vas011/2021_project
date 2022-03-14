using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class menu : MonoBehaviour
{

    public void menu_startButton()
    {
        SceneManager.LoadScene("SampleScene");
        Cursor.visible = false;
    }
    public void menu_exitButton()
    {
        Application.Quit();
    }

    public void lobby_Button()
    {
        SceneManager.LoadScene("menu");
        Cursor.visible = true;
    }

    /*
    // Start is called before the first frame update
    void Start()
    {}  
    // Update is called once per frame
    void Update()
    {}
    /**/
}
