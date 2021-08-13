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
        if(navi_Agent.velocity == Vector3.zero)
        {
            navi_Agent.SetDestination(move_point[count].position);
            count++;
        }
        
        Debug.Log(count.ToString());
    }

    // Start is called before the first frame update
    void Start()
    {
        navi_Agent = GetComponent<NavMeshAgent>();
        InvokeRepeating("monster_move" , 0f,2f);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
