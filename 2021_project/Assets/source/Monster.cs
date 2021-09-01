using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class Monster : MonoBehaviour
{
    NavMeshAgent navi_Agent;
    Animator monster_Ani;
    Transform Ptarget;
    player player_info;
    //���� ����
    [Header("Stats")]
    public float hp;
    public float attack_speed;
    public float attack_range;
    [Space(10f)]

    //���̸���ũ ���� ����
    [SerializeField]
    LayerMask player_Layermak = 0;
    //���� �þ� ����
    [SerializeField]
    float angle;
    //���� �þ� �Ÿ�
    [SerializeField]
    float distancec;

    [Header("way_point")]
    //��������Ʈ �迭 ����
    [SerializeField]
    Transform[] move_point;

    //��������Ʈ ī��Ʈ
    int count = 0;
    //�÷��̾� ã������ �����ϴ� ����
    bool fiend_player;
    //�ݶ��̴� ����
    float monster_collider;
    float player_collider;
    //���� ��������Ʈ �̵� �Լ�
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

    //�÷��̾� ã�⸦ ���� �Լ�
    void field_player()
    {
        Collider[] colls = Physics.OverlapSphere(transform.position, distancec, player_Layermak);

        if (colls.Length > 0)
        {
            Transform target_player = colls[0].transform;
            Vector3 traget_direction = (target_player.position - transform.position).normalized;
            float target_angle = Vector3.Angle(traget_direction, transform.forward);
            if (target_angle < angle * 0.5)
            {
                if (Physics.Raycast(transform.position, traget_direction, out RaycastHit hit, distancec))
                {
                    if (hit.transform.name == "Player")
                    {
                        fiend_player = true;
                        CancelInvoke("monster_move");
                        player_Attack();
                    }
                    else
                    {
                        fiend_player = false;
                        InvokeRepeating("monster_move", 2f, 5f);
                    }
                }
                Debug.Log(fiend_player.ToString());
            }
        }

        //���� ���̰� ������ ���� �� ���� �׸���
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * distancec, Color.red);
    }
    void player_Attack()
    {
        Vector3 dirToTarget = (Ptarget.position - transform.position).normalized;
        Vector3 targetPosition = Ptarget.position - dirToTarget * (monster_collider + player_collider + attack_range / 2f);
        if (fiend_player == true)
        {
            navi_Agent.destination = targetPosition;
        }
        if (navi_Agent.destination == targetPosition)
        {
            monster_Ani.SetBool("Run" , false);
            monster_Ani.SetBool("Attack01", true);
            Attack_Action();
        }
        else if(navi_Agent.destination != targetPosition)
        {
            monster_Ani.SetBool("Attack01", false);
            monster_Ani.SetBool("Run", true);
        }
    }
    void Attack_Action()
    {

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
        player_info = GetComponent<player>();
    }

    // Update is called once per frame
    void Update()
    {
        field_player();
    }
}
