using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finish : MonoBehaviour
{
    public GameManager gameManager;
    public bool player_finish;


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            player_finish = true;
        }
    }
    void Start()
    {
        player_finish = false;
    }
    // Update is called once per frame
    void Update()
    {
        if(player_finish)
        {
            player_finish = false;
            gameManager.box_finish = true;
        }
    }
}