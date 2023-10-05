using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    private GameObject player;
    void Start()
    {
        RespawnPlayer();
    }

    public void RespawnPlayer()
    {
        player = FindObjectOfType<PlayerController>().gameObject;
        player.transform.position = transform.position;
    }

    public void GameOver()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
