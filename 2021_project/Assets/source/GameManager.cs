using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    void Start()
    {
        box_finish = false;
        maps = gameManager_info[map_count];
    }

    // Update is called once per frame
    void Update()
    {
        if (box_finish)
        {
            maps.map_setAtive(false);
            map_count++;
            maps = gameManager_info[map_count];
            maps.map_setAtive(true);
            player.transform.position = maps.re_start_position.position;
            player.transform.rotation = Quaternion.Euler(0, -270, 0);
            if(map_count <= 5)
            {
                map_count = 0;
            }
        }   
        box_finish = false;
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

        public void map_setAtive(bool atcive)
        {
            map.SetActive(atcive);
        }
    }
}