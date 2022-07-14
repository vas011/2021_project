using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    /*
    [SerializeField]
    BoxCollider[] finish;
    /**/
    [SerializeField]
    player player;
    [SerializeField]
    Renderer minimap_image;
    public bool box_finish;

    [SerializeField]
    info[] gameManager_info;

    info maps;

    int map_count = 0;

    public void Game_ReStart()
    {
        player.player_die = false;
        player.player_hp = 100;
        GameObject Game_UI = GameObject.Find("Game_menu");
        Game_UI.GetComponent<Game_menu>().HP_Bar_UI();
        player.player_Animator.SetBool("Death", false);
    }

    //마우스 커서 보이기 온오프
    public void cursor_onoff(bool onoff)
    {
        if (Cursor.visible == false)
        {
            Cursor.visible = onoff;
        }
        else
        {
            Cursor.visible = onoff;
        }
    }

    void Start()
    {
        box_finish = false;
        Cursor.visible = false; // 마우스 커서 안보이게
        maps = gameManager_info[map_count];
    }

    // Update is called once per frame
    void Update()
    {
        if (box_finish)
        {
            maps.map_setAtive(false);
            map_count++;
            if (map_count == 5)
            {
                SceneManager.LoadScene("Ending");
            }
            else 
            {
                maps = gameManager_info[map_count];
                maps.map_setAtive(true);
                player.transform.position = maps.re_start_position.position;
                minimap_image.material = gameManager_info[map_count].minimap_setAtive();
                box_finish = false;
            }
        }
    }

    [System.Serializable]
    class info
    {
        //맵 정보 와 몬스터 웨이 포인트를 관리하기 편하게 구조체 코드 설계
        [SerializeField]
        GameObject map;
        [SerializeField]
        Transform[] waypoint;
        [SerializeField]
        public Transform re_start_position;
        [SerializeField]
        Material minimap;

        public void map_setAtive(bool atcive)
        {
            map.SetActive(atcive);
        }
        public Material minimap_setAtive()
        {
            return minimap;
        }
    }
}