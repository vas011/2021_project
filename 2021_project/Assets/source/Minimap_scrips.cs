using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Minimap_scrips : MonoBehaviour
{
    [SerializeField]
    Transform Player_Mark;
    [SerializeField]
    Transform Player_camera_arm;

    //플레이어 위치 찾기
    Transform Player_position;

    //카메라 위치를 Vector로 저장
    Vector3 Player_camera_vector;

    // Start is called before the first frame update
    void Start()
    {
        //플레이어 위치 변수
        Player_position = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        // 카메라 위치정보 저장
         Player_camera_vector = Player_camera_arm.rotation.eulerAngles;

        //플레이어 위치에 따라 포지션 이동
        Player_Mark.transform.position = new Vector3(Player_position.position.x, 65, Player_position.position.z);
        //플레이어 방향에 따라 방향 전환
        Player_Mark.rotation = Quaternion.Euler(90, Player_camera_vector.y, 0);
    }
}
