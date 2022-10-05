using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ParticleManager : MonoBehaviour
{
    [Header("Nomal_Hit")]

    [SerializeField]
    ParticleSystem Hit_particle;

    // 게임오브젝트 , Find() 함수를 사용하지 않고 Action함수를 사용하여 쉽고 간결하게 다른 스크립트에서 함수를 사용할 수 잇다.
    // 사용할시 반드시 using System;을 넣고 public static Action 변수이름 과 Awake() 함수를 꼭 사용해야 한다.
    
    
    public static Action Nomal_Hit;
    public static Action Boss_Paricle;

    private void Awake()
    {
        Nomal_Hit = () =>
        {
            N_Hit_Particle();
        };

    }

    public void N_Hit_Particle()
    {
        Hit_particle.Play();
    }
}
