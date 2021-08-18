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
            Debug.Log("�÷��̾� ã��!");
        }

        //���� ���̰� ������ ���� �� ���� �׸���
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
