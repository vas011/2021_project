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

    // ���ӿ�����Ʈ , Find() �Լ��� ������� �ʰ� Action�Լ��� ����Ͽ� ���� �����ϰ� �ٸ� ��ũ��Ʈ���� �Լ��� ����� �� �մ�.
    // ����ҽ� �ݵ�� using System;�� �ְ� public static Action �����̸� �� Awake() �Լ��� �� ����ؾ� �Ѵ�.


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
