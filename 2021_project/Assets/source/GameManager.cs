using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    /*
    [SerializeField]
    BoxCollider[] finish;
    /**/
    [SerializeField]
    player player;
    public bool box_finish;

    [SerializeField]
    info[] gameManager_info;

    info maps;

    int map_count = 0;

    //���콺 Ŀ�� ���̱� �¿���
    public void cursor_onoff(bool onoff)
    {
        if (onoff)
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
        Cursor.visible = false; // ���콺 Ŀ�� �Ⱥ��̰�
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
                box_finish = false;
            }
        }
    }

    [System.Serializable]
    class info
    {
        //�� ���� �� ���� ���� ����Ʈ�� �����ϱ� ���ϰ� ����ü �ڵ� ����
        [SerializeField]
        GameObject map;
        [SerializeField]
        Transform[] waypoint;
        [SerializeField]
        public Transform re_start_position;

        public void map_setAtive(bool atcive)
        {
            map.SetActive(atcive);
        }
    }
}