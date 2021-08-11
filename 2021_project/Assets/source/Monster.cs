using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class Monster : MonoBehaviour
{
    NavMeshAgent navi_Agent;

    [SerializeField]
    Transform[] move_point;

    int count = 0;

    void monster_move()
    {
        if (count >= move_point.Length)
        {
            count = 0;
        }
        navi_Agent.SetDestination(move_point[count].position);
        count++;
        Debug.Log(count.ToString());
    }

    // Start is called before the first frame update
    void Start()
    {
        navi_Agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine("monster_move", 3f);
    }
}
