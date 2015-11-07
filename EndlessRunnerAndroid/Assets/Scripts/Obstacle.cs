﻿using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
        {
            Debug.Log("Player Hit");
            other.collider.GetComponent<Player>().PlayerDeath();
            
        }
    }
}