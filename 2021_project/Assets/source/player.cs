using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{

    Animator player_Animator;

    
    public int player_hp;
    public int player_speed;

    bool player_move;

    // Start is called before the first frame update
    void Start()
    {
        player_Animator = GetComponent<Animator>();
    }
    void move()
    {
        player_move = true;
        Vector3 move_dir = new Vector3(Input.GetAxis("Horizontal"),0, Input.GetAxis("Vertical"));
        if (move_dir.x == 0 && move_dir.z == 0)
        {
            player_move = false;
            player_Animator.SetBool("Idle",true);
            player_Animator.SetBool("Run", false);
        }
        player_Animator.SetBool("Idle", false);
        player_Animator.SetBool("Run", true);
        transform.position += move_dir * player_speed * Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }
}
