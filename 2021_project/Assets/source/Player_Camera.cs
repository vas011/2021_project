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

    /* ��� ����
     * ������� ������ ���� ����*/
     
    //ī�޶� ������ �Լ�
    void camera_move()
    {
        //���콺�� �¿� ������ �Է°� �޾ƿ���
        Vector2 input_mouse = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        //ī�޶� �ޱ� �� ����
        Vector3 camera_Angle = camera_Arm.rotation.eulerAngles;
        float x = camera_Angle.y + input_mouse.x;

        //ī�޶� �¿� �̵� ���� �ڵ�
        if (x < 180f) // ������ ����
        {
            x = Mathf.Clamp(x , -1 , 90);
        }
        else // ���� ����
        {
            x = Mathf.Clamp(x, 280, 365);
        }

        //���콺 �̵����� ���� ī�޶� ���� �̵� �ڵ� ����
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


        //rotation ������ Quaternion.Euler() �Լ��� ���Ͽ� Vector3 x,y,z �� ���� ���
        //transform.rotation = Quaternion.Euler(30,player.transform.rotation.eulerAngles.y,0);

    }
}
