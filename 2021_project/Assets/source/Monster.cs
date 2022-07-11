using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class Monster : MonoBehaviour
{
    NavMeshAgent navi_Agent;
    Animator monster_Ani;
    Transform Ptarget;
    GameObject player_info;

    bool isDead;

    //몬스터 스탯
    [Header("Stats")]
    public float hp;
    public float attack_speed;
    public float attack_range;
    public float Attack_damage;
    [Space(20f)]

    //레이마스크 설정 변수
    [SerializeField]
    LayerMask player_Layermak = 0;
    //몬스터 시야 각도
    [SerializeField]
    float angle;
    //몬스터 시야 거리
    [SerializeField]
    float distancec;

    [Header("way_point")]
    //웨이포인트 배열 변수
    [SerializeField]
    Transform[] move_point;
    //무기 콜라이더
    [Header("weapon")]
    [SerializeField]
    Collider weapon_L;

    //웨이포인트 카운트
    int count = 0;
    //플레이어 찾았음을 저장하는 변수
    bool fiend_player;
    //콜라이더 변수
    float monster_collider;
    float player_collider;
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
            //monster_Ani.SetBool("Run", false);
        }

    }

    //플레이어 찾기를 위한 함수
    void field_player()
    {
        //현재 위치 와 지정한 거리 , 플레이어_레이어 마스크 조건으로 플레이어를 찾아 Collider 배열에 저장
        Collider[] colls = Physics.OverlapSphere(transform.position, distancec, player_Layermak);
        //1개 이상이 나올경우 조건문 실행
        if (colls.Length > 0 )
        {
            //플레이어 위치 저장
            Transform target_player = colls[0].transform;
            //플레이어 위치 와 몬스터 위치 거리 계산하고 정규화 시켜 Vector3로 저장
            Vector3 traget_direction = (target_player.position - transform.position).normalized;
            //몬스터 시야의 들어오는지 거리 확인값(플레이어의 거리 와 몬스터 바라보는 방향)
            float target_angle = Vector3.Angle(traget_direction, transform.forward);
            //플레이어 위치 가 몬스터 시야값 보다 낮으면 조건문 실행
            if (target_angle < angle * 0.5)
            {
                if (Physics.Raycast(transform.position, traget_direction, out RaycastHit hit, distancec))
                {
                    //플레이어 사정거리가 들어오고 죽지 않았다면 공격 실행
                    if (hit.transform.name == "Player" && player_info.GetComponent<player>().player_die != true)
                    {
                        
                        fiend_player = true;
                        CancelInvoke("monster_move");
                        player_Attack();
                    }
                    else
                    {
                        fiend_player = false;
                        InvokeRepeating("monster_move", 1f, 5f);
                    }
                }
            }
        }
        //플레이어가 검색이 안되면 실행
        else
        {
            monster_Ani.SetBool("Attack01", false);
            InvokeRepeating("monster_move", 1f, 5f);
            fiend_player = false;
        }
        //눈에 보이게 광선의 방향 및 길이 그리기
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * distancec, Color.red);
    }
    void player_Attack()
    {
        Vector3 dirToTarget = (Ptarget.position - transform.position).normalized;
        Vector3 targetPosition = Ptarget.position - dirToTarget * (monster_collider + player_collider + attack_range / 2.5f);
        if (fiend_player == true)
        {
            navi_Agent.destination = targetPosition;
        }
        if (navi_Agent.destination == targetPosition || fiend_player)
        {
            monster_Ani.SetBool("Run" , false);
            monster_Ani.SetBool("Attack01", true);
            //Attack_Action();
        }
        else if(navi_Agent.destination != targetPosition)
        {
            monster_Ani.SetBool("Attack01", false);
            monster_Ani.SetBool("Run", true);
        }
    }
    
    //공격 이벤트 발생 함수
    void Attack_Action()
    {
        if(fiend_player == true)
        {
            player_info.GetComponent<player>().Player_Damage(Attack_damage);
        }
        //Debug.Log("공격이벤트 발생!!");
    }
    public void Monster_Damage(float Damage)
    {
        if(hp <= 0 && isDead == false)
        {
            hp = 0;
            isDead = true;
            die(hp);
        }
        hp = hp - Damage;
    }

    void die(float Monster_HP)
    {
        float HP = Monster_HP;
        if (HP == 0)
        {
            GameObject Ative_Monster = GameObject.Find("Monster");
            navi_Agent.speed = 0;
            monster_Ani.SetTrigger("Dead");
            Destroy(Ative_Monster,3f);
        }
    }

    private void Awake()
    {
        navi_Agent = GetComponent<NavMeshAgent>();
        monster_Ani = GetComponent<Animator>();

    }

    // Start is called before the first frame update
    void Start()
    {
        Ptarget = GameObject.FindGameObjectWithTag("Player").transform;
        monster_collider = GetComponent<CapsuleCollider>().radius;
        player_collider = Ptarget.GetComponent<CapsuleCollider>().radius;   
        InvokeRepeating("monster_move", 2f, 5f);
        player_info = GameObject.Find("Player");
        isDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        field_player();
    }
}
