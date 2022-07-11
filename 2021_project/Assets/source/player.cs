using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{

    public Animator player_Animator;
    Rigidbody player_rigidbody;
    [SerializeField]
    Transform player_body;
    [SerializeField]
    public Transform camer_arm;
    [SerializeField]
    Sound Player_sfx;

    GameManager gameManager;
    public AudioSource Player_sound;
    GameObject Game_UI;
    GameObject monster;

    public int player_hp;
    public int player_speed;
    public float player_Stamina;
    public float player_Attack_Damage;

    bool player_move;
    bool player_Attack;
    bool player_run;
    public bool player_die;
    bool monster_chack;

    float Attack_time;
    int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        player_move = false;
        player_Attack = false;
        player_run = false;
        player_die = false;
        player_Animator = GetComponent<Animator>();
        Player_sound = GetComponent<AudioSource>();
        player_rigidbody = GetComponent<Rigidbody>();
        InvokeRepeating("Attack", 10f, 2f);
        Game_UI = GameObject.Find("Game_menu");
        monster = GameObject.Find("Monster");
    }

    void move()
    {
        #region ������ ������ �ڵ�( �ּ� ó�� �� )
        //Vector3 move_dir = Vector3.zero;        
        //move_dir = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        //Vector3 P_move = transform.forward = camer_arm.forward;

        /* ������ ������ 
         * 
        if (move_dir.magnitude == 0)
        {
            player_move = false;
            player_Animator.SetFloat("speed", 0f);
        }

        //����
        else if (move_dir.x == 0f && move_dir.z != 0)
        {
            player_move = true;
            player_Animator.SetFloat("speed", 2f);
            if (move_dir.z < 0)
            {
                //Debug.Log("��" + "z : " + move_dir.z.ToString());
                transform.Rotate(new Vector3(0, 180, 0));
                transform.position -= P_move * player_speed * Time.deltaTime;
            }
            else if (move_dir.z > 0)
            {
                //Debug.Log("�� " + "z : " + move_dir.z.ToString());
                transform.position += P_move * player_speed * Time.deltaTime;
            }
        }
        //�¿�
        else
        {
            player_move = true;
            player_Animator.SetFloat("speed", 2f);
            if (move_dir.x < 0)
            {
                //Debug.Log("�� " + "x : " + move_dir.x.ToString());
                transform.Rotate(new Vector3(0, -90, 0));
                transform.position += transform.forward * player_speed * Time.deltaTime;
            }
            else if (move_dir.x > 0)
            {
                //Debug.Log("�� " + "x : " + move_dir.x.ToString());
                transform.Rotate(new Vector3(0, 90, 0));
                transform.position += transform.forward * player_speed * Time.deltaTime;
            }
        }

        /**/
        #endregion


        /* �ε巯�� �÷��̾� ������ �ڵ� ��� */

        Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        if (moveInput.magnitude == 0 || player_die == true)
        {
            player_move = false;
            player_Animator.SetFloat("speed", 0f);
            moveInput = Vector2.zero;
        }

        //Ű�Է��� ���Ë�
        if (moveInput.magnitude != 0)
        {
            //ĳ���� ������ �ν��ϰ� ���� ����
            player_move = true;
            Vector3 lookForward = new Vector3(camer_arm.forward.x, 0f, camer_arm.forward.z).normalized;
            Vector3 lookRight = new Vector3(camer_arm.right.x, 0f, camer_arm.right.z).normalized;
            Vector3 smoos_move = lookForward * moveInput.y + lookRight * moveInput.x;

            player_body.forward = smoos_move;
            transform.position += smoos_move * player_speed * Time.deltaTime;
            player_Animator.SetFloat("speed", 2f);
        }

        /**/

        //esc Ű�� �Ͻ����� Ű �ڵ� ����
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //������Ʈ�� ������ �ִ� �Լ��� ����ϱ� ���� �Ʒ��� ���� �ڵ� ����

            //���ӿ�����Ʈ ���� �����Ͽ� Game_menu ������Ʈ ã�Ƽ� ������ ����
            //������Ʈ�� ������ �ִ� ��ũ��Ʈ �Լ� ���
            Game_UI.GetComponent<Game_menu>().menu_onoff();
            Game_UI.GetComponent<Game_menu>().Game_paues();
        }


    }
    void Run(bool player_move)
    {
        //����ƮŰ �޸��� �ڵ�
        if (Input.GetKeyDown(KeyCode.LeftShift) && player_move)
        {
            player_run = true;
            player_speed = player_speed * 2;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            player_run = false;
            player_speed = 10;
        }
        if (player_run == true)
        {
            player_Stamina -= 20 * Time.deltaTime;
            Game_UI.GetComponent<Game_menu>().Stamina_Bar_UI();
            if (player_Stamina <= 0)
            {
                player_Stamina = 0;
                player_speed = 10;
            }
        }
        else
        {
            player_Stamina += 10 * Time.deltaTime;
            Game_UI.GetComponent<Game_menu>().Stamina_Bar_UI();
            if (player_Stamina >= 100)
            {
                player_Stamina = 100;
            }
        }
    }

    void Attack()
    {
        Attack_time += Time.deltaTime;
        if (Attack_time > 1.5f)
        {
            Attack_time = 0;
            count = 0;
            //Debug.Log(Attack_time.ToString());
            player_Attack = false;
        }
        else
        {
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            player_Attack = true;
            count++;

            if (player_Attack)
            {
                switch (count)
                {
                    case 1:
                            player_Animator.SetTrigger("Attack1");
                            Player_Attak_Action();
                        break;

                    case 2:
                        if (player_Attack == true)
                        {
                           player_Animator.SetTrigger("Attack2");
                           Player_Attak_Action();
                        }
                        break;
                        
                    default:
                        count = 0;
                        player_Attack = false;
                        break;
                }
            }
        }
    }
    void Player_Attak_Action()
    {   
        if(monster != null && monster_chack)
        {
            Debug.Log("����!");
            monster.GetComponent<Monster>().Monster_Damage(player_Attack_Damage);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Monster")
        {
            monster_chack = true;
            Debug.Log("���� �浹 Ȯ��");
        }
    }
    public void Player_Damage(float Damage)
    {
        player_hp = player_hp - ((int)Damage);
        Game_UI.GetComponent<Game_menu>().HP_Bar_UI();
        die(player_hp);
    }
    void die(float player_hp)
    {
        if (player_hp <= 0)
        {
            player_Animator.SetBool("Death", true);
            player_die = true;
            Cursor.visible = true;
            Game_UI.GetComponent<Game_menu>().Game_Over();
        }

    }
    void Player_footstep_sound()
    {
        Player_sfx.Player_SFX_Play();
    }

    void Update()
    {
        if (player_Attack != false)
        {
            player_Attack = false;
        }
        move();
        Attack();
        Run(player_move);
    }
}