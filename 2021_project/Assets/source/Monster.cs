using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class Monster : MonoBehaviour
{
    NavMeshAgent navi_Agent;
    Animator monster_Ani;

    //���̸���ũ ���� ����
    [SerializeField]
    LayerMask player_Layermak = 0;
    //���� �þ� ����
    [SerializeField]
    float angle;
    //���� �þ� �Ÿ�
    [SerializeField]
    float distancec;


    //��������Ʈ �迭 ����
    [SerializeField]
    Transform[] move_point;

    //��������Ʈ ī��Ʈ
    int count = 0;
    //�÷��̾� ã������ �����ϴ� ����
    bool fiend_player;

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

        //���� ���̰� ������ ���� �� ���� �׸���
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
