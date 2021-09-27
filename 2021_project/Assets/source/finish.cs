using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finish : MonoBehaviour
{
    GameObject player;
    GameManager gameManager;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == player)
        {
            gameManager.box_finish = true;
        }
    }

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Start()
    {
        gameManager = GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
    }
}
