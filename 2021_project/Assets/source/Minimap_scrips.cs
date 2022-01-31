using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Minimap_scrips : MonoBehaviour
{
    [SerializeField]
    GameObject Player_Mark;

    Transform Player_position;

    // Start is called before the first frame update
    void Start()
    {
        Player_position = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Player_Mark.transform.position = new Vector3(Player_position.position.x, 55, Player_position.position.z);
    }
}
