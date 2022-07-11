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

    //���� ����
    [Header("Stats")]
    public float hp;
    public float attack_speed;
    public float attack_range;
    public float Attack_damage;
    [Space(20f)]

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
    //���� �ݶ��̴�
    [Header("weapon")]
    [SerializeField]
    Collider weapon_L;

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
            //monster_Ani.SetBool("Run", false);
        }

    }

    //�÷��̾� ã�⸦ ���� �Լ�
    void field_player()
    {
        //���� ��ġ �� ������ �Ÿ� , �÷��̾�_���̾� ����ũ �������� �÷��̾ ã�� Collider �迭�� ����
        Collider[] colls = Physics.OverlapSphere(transform.position, distancec, player_Layermak);
        //1�� �̻��� ���ð�� ���ǹ� ����
        if (colls.Length > 0 )
        {
            //�÷��̾� ��ġ ����
            Transform target_player = colls[0].transform;
            //�÷��̾� ��ġ �� ���� ��ġ �Ÿ� ����ϰ� ����ȭ ���� Vector3�� ����
            Vector3 traget_direction = (target_player.position - transform.position).normalized;
            //���� �þ��� �������� �Ÿ� Ȯ�ΰ�(�÷��̾��� �Ÿ� �� ���� �ٶ󺸴� ����)
            float target_angle = Vector3.Angle(traget_direction, transform.forward);
            //�÷��̾� ��ġ �� ���� �þ߰� ���� ������ ���ǹ� ����
            if (target_angle < angle * 0.5)
            {
                if (Physics.Raycast(transform.position, traget_direction, out RaycastHit hit, distancec))
                {
                    //�÷��̾� �����Ÿ��� ������ ���� �ʾҴٸ� ���� ����
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
        //�÷��̾ �˻��� �ȵǸ� ����
        else
        {
            monster_Ani.SetBool("Attack01", false);
            InvokeRepeating("monster_move", 1f, 5f);
            fiend_player = false;
        }
        //���� ���̰� ������ ���� �� ���� �׸���
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
    
    //���� �̺�Ʈ �߻� �Լ�
    void Attack_Action()
    {
        if(fiend_player == true)
        {
            player_info.GetComponent<player>().Player_Damage(Attack_damage);
        }
        //Debug.Log("�����̺�Ʈ �߻�!!");
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
