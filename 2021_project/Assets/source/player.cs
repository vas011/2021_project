using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{

    Animator player_Animator;
    [SerializeField]
    Transform player_body;
    [SerializeField]
    public Transform camer_arm;
    [SerializeField]
    Sound Player_sfx;

    GameManager gameManager;
    public AudioSource Player_sound;

    public int player_hp;
    public int player_speed;

    bool player_move;
    bool player_Attack;

    float Attack_time;
    int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        player_move = false;
        player_Attack = false;
        player_Animator = GetComponent<Animator>();
        Player_sound = GetComponent<AudioSource>();
        InvokeRepeating("Attack", 10f, 2f);
    }

    void move()
    {
        Vector3 move_dir = Vector3.zero;
        move_dir = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        Vector3 P_move = transform.forward = camer_arm.forward;
        if (move_dir.x == 0 && move_dir.z == 0)
        {
            player_move = false;
            player_Animator.SetFloat("speed", 0f);
        }
        //상하
        else if (move_dir.x == 0f && move_dir.z != 0)
        {
            player_move = true;
            player_Animator.SetFloat("speed", 2f);
            if (move_dir.z < 0)
            {
                //Debug.Log("하" + "z : " + move_dir.z.ToString());
                transform.Rotate(new Vector3(0, 180, 0));
                transform.position -= P_move * player_speed * Time.deltaTime;
            }
            else if (move_dir.z > 0)
            {
                //Debug.Log("상 " + "z : " + move_dir.z.ToString());
                transform.position += P_move * player_speed * Time.deltaTime;
            }
        }
        //좌우
        else
        {
            player_move = true;
            player_Animator.SetFloat("speed", 2f);
            if (move_dir.x < 0)
            {
                //Debug.Log("좌 " + "x : " + move_dir.x.ToString());
                transform.Rotate(new Vector3(0, -90, 0));
                transform.position += transform.forward * player_speed * Time.deltaTime;
            }
            else if (move_dir.x > 0)
            {
                //Debug.Log("우 " + "x : " + move_dir.x.ToString());
                transform.Rotate(new Vector3(0, 90, 0));
                transform.position += transform.forward * player_speed * Time.deltaTime;
            }
        }
        //esc 키로 일시중지 키 코드 적용
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            //오브젝트가 가지고 있는 함수를 사용하기 위해 아래와 같이 코드 적용

            //게임오브젝트 변수 선언하여 Game_menu 오브젝트 찾아서 변수에 저장
            GameObject Game_UI = GameObject.Find("Game_menu");
            //오브젝트가 가지고 있는 스크립트 함수 사용
            Game_UI.GetComponent<Game_menu>().menu_onoff();
            Game_UI.GetComponent<Game_menu>().Game_paues();
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
                        break;

                    case 2:
                        if (player_Attack == true)
                        {
                            player_Animator.SetTrigger("Attack2");
                        }
                        break;
                    default:
                        count = 0;
                        player_Attack = false;
                        break;
                }
            }
            Debug.Log(count.ToString());
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
    }
}