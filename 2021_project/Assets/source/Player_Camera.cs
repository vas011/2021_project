using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Camera : MonoBehaviour
{
    [SerializeField]
    GameObject player;

    public float speed;

    float datamouseX = 0;

    void camera_move()
    {
        float save_mouseX = Input.GetAxis("Mouse X") * speed;
        datamouseX += save_mouseX;

        transform.eulerAngles = new Vector3(30 , datamouseX, 0);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        camera_move();
        transform.position = player.transform.position + new Vector3(0, 5, -5);
    }
}
