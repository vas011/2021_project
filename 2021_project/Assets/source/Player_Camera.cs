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

    Vector3 camera_Angle;
    float x;
    /* ��� ����
     * ������� ������ ���� ����*/

    //ī�޶� ������ �Լ�
    void camera_move()
    {
        //���콺�� �¿� ������ �Է°� �޾ƿ���
        Vector2 input_mouse = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        /*
        //ī�޶� �¿� �̵� ���� �ڵ�
        if (x > 0) // ������ ����
        {
            x = Mathf.Clamp(x , -1, 90);
            Debug.Log("���콺 ������");
        }
        else if (x <= 0.05)// ���� ����
        {
            x = Mathf.Clamp(x, -90 , 0);
            Debug.Log("���콺 ����");
        }
        /**/
        x += camera_Angle.y + input_mouse.x;

        //���콺 �̵����� ���� ī�޶� ���� �̵� �ڵ� ����
        camera_Arm.rotation = Quaternion.Euler(camera_Angle.x, x, camera_Angle.z);
    }
    /**/


    // Start is called before the first frame update
    void Start()
    {
        camera_Angle = camera_Arm.rotation.eulerAngles;
        x = 0;
    }

    // Update is called once per frame
    void Update()
    {
        camera_move();

        //rotation ������ Quaternion.Euler() �Լ��� ���Ͽ� Vector3 x,y,z �� ���� ���
        //transform.rotation = Quaternion.Euler(30,player.transform.rotation.eulerAngles.y,0);

    }
}
