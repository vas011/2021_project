using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    /*
    [SerializeField]
    BoxCollider[] finish;
    /**/
    [SerializeField]
    info[] gameManager_info;

    public bool box_finish;

    int map_count = 0;

    void Start()
    {
        box_finish = false; 
    }

    // Update is called once per frame
    void Update()
    {

    }

    [System.Serializable]
    class info
    {
        //�� ���� �� ���� ���� ����Ʈ�� �����ϱ� ���ϰ� ����ü �ڵ� ����
        [SerializeField]
        GameObject map;
        [SerializeField]
        Transform[] waypoint;
        [SerializeField]
        Collider finish_collider;
    }
}