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

    //�÷��̾� ��ġ ã��
    Transform Player_position;

    //ī�޶� ��ġ�� Vector�� ����
    Vector3 Player_camera_vector;

    // Start is called before the first frame update
    void Start()
    {
        //�÷��̾� ��ġ ����
        Player_position = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        // ī�޶� ��ġ���� ����
         Player_camera_vector = Player_camera_arm.rotation.eulerAngles;

        //�÷��̾� ��ġ�� ���� ������ �̵�
        Player_Mark.transform.position = new Vector3(Player_position.position.x, 65, Player_position.position.z);
        //�÷��̾� ���⿡ ���� ���� ��ȯ
        Player_Mark.rotation = Quaternion.Euler(90, Player_camera_vector.y, 0);
    }
}
