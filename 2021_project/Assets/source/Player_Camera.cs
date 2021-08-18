using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Camera : MonoBehaviour
{
    [SerializeField]
    Transform player;
    [SerializeField]
    Transform camera_Arm;

    public float speed;

    /* 기능 중지
     * 사용할지 안할지 추후 설정*/
     
    //카메라 움직임 함수
    void camera_move()
    {
        //마우스의 좌우 움직임 입력값 받아오기
        Vector2 input_mouse = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        //카메라 앵글 값 저장
        Vector3 camera_Angle = camera_Arm.rotation.eulerAngles;
        float x = camera_Angle.y + input_mouse.x;

        //카메라 좌우 이동 제한 코드
        if (x < 180f) // 오른쪽 제한
        {
            x = Mathf.Clamp(x , -1 , 90);
        }
        else // 왼쪽 제한
        {
            x = Mathf.Clamp(x, 280, 365);
        }

        //마우스 이동으로 인한 카메라 시점 이동 코드 적용
        camera_Arm.rotation = Quaternion.Euler(camera_Angle.x, x, camera_Angle.z);
    }
    /**/


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        camera_move();


        //rotation 설정을 Quaternion.Euler() 함수를 통하여 Vector3 x,y,z 축 값을 사용
        //transform.rotation = Quaternion.Euler(30,player.transform.rotation.eulerAngles.y,0);

    }
}
