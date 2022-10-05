using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ParticleManager : MonoBehaviour
{
    [Header("Nomal_Hit")]

    [SerializeField]
    ParticleSystem Hit_particle;

    // ���ӿ�����Ʈ , Find() �Լ��� ������� �ʰ� Action�Լ��� ����Ͽ� ���� �����ϰ� �ٸ� ��ũ��Ʈ���� �Լ��� ����� �� �մ�.
    // ����ҽ� �ݵ�� using System;�� �ְ� public static Action �����̸� �� Awake() �Լ��� �� ����ؾ� �Ѵ�.
    
    
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
