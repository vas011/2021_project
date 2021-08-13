using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Camera : MonoBehaviour
{
    [SerializeField]
    GameObject player;

    public float speed;

    float datamouseX = 0;


    /* ��� ����
     * ������� ������ ���� ����*/
     
    //ī�޶� ������ �Լ�
    void camera_move()
    {
        //���콺�� �¿� ������ �Է°� �޾ƿ���
        float save_mouseX = Input.GetAxis("Mouse X") * speed;
        //���콺 �̵��� ����;;
        datamouseX += save_mouseX;
        //ī�޶� x�� �̵� ���� �ڵ� ����
        datamouseX = Mathf.Clamp(datamouseX, -90, 90);
        //���콺 �̵����� ���� ī�޶� ���� �̵� �ڵ� ����
        transform.eulerAngles = new Vector3(30, datamouseX, 0);

    }
    /**/


    // Start is called before the first frame update
    void Start()
    {
        //�⺻ ī�޶� �� �ʱ�ȭ
        datamouseX = 0;
    }

    // Update is called once per frame
    void Update()
    {

        //ī�޶� ��ġ ���� (��ġ ������)
        transform.position = player.transform.localPosition + new Vector3(0, 5, -5);
        camera_move();
        //rotation ������ Quaternion.Euler() �Լ��� ���Ͽ� Vector3 x,y,z �� ���� ���
        //transform.rotation = Quaternion.Euler(30,player.transform.rotation.eulerAngles.y,0);

    }
}
