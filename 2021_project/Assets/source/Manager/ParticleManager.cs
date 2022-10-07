using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ParticleManager : MonoBehaviour
{
    [Header("Nomal_Hit")]

    [SerializeField]
    ParticleSystem Hit_particle;

    [Header("Player_Particle")]
    [SerializeField]
    ParticleSystem P_Hit_particle_L;
    [SerializeField]
    ParticleSystem P_Hit_particle_R;

    // 게임오브젝트 , Find() 함수를 사용하지 않고 Action함수를 사용하여 쉽고 간결하게 다른 스크립트에서 함수를 사용할 수 잇다.
    // 사용할시 반드시 using System;을 넣고 public static Action 변수이름 과 Awake() 함수를 꼭 사용해야 한다.


    public static Action Monster_Particle;
    public static Action<int> Player_Hit;
    public static Action Boss_Paricle;

    private void Awake()
    {
        Monster_Particle = () =>
        {
            N_Hit_Particle();
        };

        Player_Hit = (count) =>
        {
            Player_Particle(count);
        };

    }

    public void N_Hit_Particle()
    {
        Hit_particle.Play();
    }

    public void Player_Particle(int count)
    {
        switch(count)
        {
            case 1:
                P_Hit_particle_L.Play();
                break;
            case 2:
                P_Hit_particle_R.Play();
                break;
        }
    }
}
