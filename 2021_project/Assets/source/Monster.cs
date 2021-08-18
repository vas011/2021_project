using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class Monster : MonoBehaviour
{
    NavMeshAgent navi_Agent;
    Animator monster_Ani;

    //레이마스크 설정 변수
    [SerializeField]
    LayerMask player_Layermak = 0;
    //몬스터 시야 각도
    [SerializeField]
    float angle;
    //몬스터 시야 거리
    [SerializeField]
    float distancec;


    //웨이포인트 배열 변수
    [SerializeField]
    Transform[] move_point;

    //웨이포인트 카운트
    int count = 0;
    //플레이어 찾았음을 저장하는 변수
    bool fiend_player;


    void monster_move()
    {
        if (count >= move_point.Length)
        {
            count = 0;
        }
        if (navi_Agent.velocity == Vector3.zero)
        {
            navi_Agent.SetDestination(move_point[count].position);
            monster_Ani.SetBool("Run", true);
            count++;
        }
        if(navi_Agent.velocity != Vector3.zero)
        {
            monster_Ani.SetBool("Run", false);
        }

    }

    void field_player()
    {
        Collider[] colls = Physics.OverlapSphere(transform.position, distancec, player_Layermak);

        if(colls.Length > 0)
        {
            fiend_player = true;
            Debug.Log("플레이어 찾음!");
        }

        //눈에 보이게 광선의 방향 및 길이 그리기
        Debug.DrawRay(transform.position , transform.TransformDirection(Vector3.forward)* distancec,Color.red);
    }

    // Start is called before the first frame update
    void Start()
    {
        navi_Agent = GetComponent<NavMeshAgent>();
        monster_Ani = GetComponent<Animator>();
        InvokeRepeating("monster_move" , 2f,5f);
    }

    // Update is called once per frame
    void Update()
    {
        field_player();
    }
}
