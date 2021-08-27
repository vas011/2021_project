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

    //몬스터 웨이포인트 이동 함수
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
        if (navi_Agent.velocity != Vector3.zero)
        {
            monster_Ani.SetBool("Run", false);
        }

    }

    //플레이어 찾기를 위한 함수
    void field_player()
    {
        Collider[] colls = Physics.OverlapSphere(transform.position, distancec, player_Layermak);

        if (colls.Length > 0)
        {
            Transform target_player = colls[0].transform;
            Vector3 traget_direction = (target_player.position - transform.position).normalized;
            float target_angle = Vector3.Angle(traget_direction , transform.forward);
            if(target_angle < angle * 0.5)
            {
                if (Physics.Raycast(transform.position , traget_direction, out RaycastHit hit , distancec))
                {                      
                    if (hit.transform.name == "Player")
                    {
                        fiend_player = true;
                    }
                    else
                    {
                        fiend_player = false;
                    }
                }
                Debug.Log(fiend_player.ToString());
            }
        }

        //눈에 보이게 광선의 방향 및 길이 그리기
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * distancec, Color.red);
    }

    private void Awake()
    {
        navi_Agent = GetComponent<NavMeshAgent>();
        monster_Ani = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("monster_move", 2f, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        field_player();
    }
}
