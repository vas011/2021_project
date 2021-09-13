using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{

    Animator player_Animator;
    [SerializeField]
    Transform player_body;
    [SerializeField]
    Transform camer_arm;


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
        InvokeRepeating("Attack", 2f, 5f);
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
                Debug.Log("하" + "z : " + move_dir.z.ToString());
                transform.Rotate(new Vector3(0, 180, 0));
                transform.position -= P_move * player_speed * Time.deltaTime;
            }
            else if (move_dir.z > 0)
            {
                Debug.Log("상 " + "z : " + move_dir.z.ToString());
                transform.position += P_move * player_speed * Time.deltaTime;
            }
            //Debug.Log(move_dir.z.ToString());
        }
        //좌우
        else
        {
            player_move = true;
            player_Animator.SetFloat("speed", 2f);
            if (move_dir.x < 0)
            {
                Debug.Log("좌 " + "x : " + move_dir.x.ToString());
                transform.Rotate(new Vector3(0, -90, 0));
                transform.position += transform.forward * player_speed * Time.deltaTime;
            }
            else if (move_dir.x > 0)
            {
                Debug.Log("우 " + "x : " + move_dir.x.ToString());
                transform.Rotate(new Vector3(0, 90, 0));
                transform.position += transform.forward * player_speed * Time.deltaTime;
            }
        }
    }

    void Attack()
    {
        Attack_time += Time.deltaTime;
        if(Attack_time >3.0f)
        {
           // Attack_time = 0;
            Debug.Log(Attack_time.ToString());
            player_Animator.SetBool("Attack1", false);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            player_move = false;
            player_Attack = true;

            player_Animator.SetBool("Attack1", true);
            count++;
            Debug.Log("공격 버튼 확인!!");
        }

        player_Attack = false;
    }

    // Update is called once per frame
    void Update()
    {
        move();
        Attack();
    }
}
