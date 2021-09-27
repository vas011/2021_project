using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    GameObject[] map;
    [SerializeField]
    BoxCollider[] finish;
    [SerializeField]
    monster_waypoint[] waypoints;

    // Start is called before the first frame update
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



