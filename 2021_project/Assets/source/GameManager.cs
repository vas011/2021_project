using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //맵 정보 와 몬스터 웨이 포인트를 관리하기 편하게 구조체 코드 설계
    [SerializeField]
    GameObject[] map;
    /*
    [SerializeField]
    BoxCollider[] finish;
    /**/
    [SerializeField]
    monster_waypoint[] waypoints;


    int map_count = 0;
    public bool box_finish;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    [System.Serializable]
    class monster_waypoint
    {
        [SerializeField]
        Transform[] waypoint;
    }
}