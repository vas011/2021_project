using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    GameObject[] map;
    /*
    [SerializeField]
    BoxCollider[] finish;
    /**/
    [SerializeField]
    monster_waypoint[] waypoints;

    public bool box_finish;
    
    
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(box_finish.ToString());
        if(box_finish)
        {
            Debug.Log("µµÂø!");
        }
    }

    [System.Serializable]
    class monster_waypoint
    {
        [SerializeField]
        Transform[] waypoint;
    }

}



