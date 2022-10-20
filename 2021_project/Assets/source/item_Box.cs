using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class item_Box : MonoBehaviour
{
    //박스 오브젝트
    [SerializeField]
    GameObject Box;
    //박스잔해
    [SerializeField]
    GameObject Box_Destroy;
    //박스 꺠지는 파티클
    [SerializeField]
    ParticleSystem break_particle_1;
    [SerializeField]
    ParticleSystem break_particle_2;

    Animator Box_Ani;

    public static Action Box_Action;

    private void Start()
    {
        Box_Ani = GetComponent<Animator>();
    }

    private void Awake()
    {
        Box_Action = () =>
        {
            box_break();
        };

    }
    public void box_break()
    {
        Box.SetActive(false);
        Box_Destroy.SetActive(true);

        Box_Ani.SetTrigger("Box_break_Trigger");
        break_particle_1.Play();
        break_particle_2.Play();

        Destroy(Box_Destroy, 3.0f);
    }

}
