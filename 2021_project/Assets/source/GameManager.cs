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
    info[] gameManager_info;

    public bool box_finish;

    int map_count = 0;

    void Start()
    {
        box_finish = false; 
    }

    // Update is called once per frame
    void Update()
    {

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
        Collider finish_collider;
    }
}