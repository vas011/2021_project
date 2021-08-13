using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Camera : MonoBehaviour
{
    [SerializeField]
    GameObject player;

    public float speed;

    float datamouseX = 0;


    /* 기능 중지
     * 사용할지 안할지 추후 설정*/
     
    //카메라 움직임 함수
    void camera_move()
    {
        //마우스의 좌우 움직임 입력값 받아오기
        float save_mouseX = Input.GetAxis("Mouse X") * speed;
        //마우스 이동값 저장;;
        datamouseX += save_mouseX;
        //카메라 x축 이동 제한 코드 적용
        datamouseX = Mathf.Clamp(datamouseX, -90, 90);
        //마우스 이동으로 인한 카메라 시점 이동 코드 적용
        transform.eulerAngles = new Vector3(30, datamouseX, 0);

    }
    /**/


    // Start is called before the first frame update
    void Start()
    {
        //기본 카메라 축 초기화
        datamouseX = 0;
    }

    // Update is called once per frame
    void Update()
    {

        //카메라 위치 설정 (위치 고정형)
        transform.position = player.transform.localPosition + new Vector3(0, 5, -5);
        camera_move();
        //rotation 설정을 Quaternion.Euler() 함수를 통하여 Vector3 x,y,z 축 값을 사용
        //transform.rotation = Quaternion.Euler(30,player.transform.rotation.eulerAngles.y,0);

    }
}
