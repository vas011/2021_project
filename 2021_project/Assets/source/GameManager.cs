using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    /*
    [SerializeField]
    BoxCollider[] finish;
    /**/
    public player player;
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
            player.transform.rotation = new Quaternion(0,180,0,0);
        }
        box_finish = false;
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