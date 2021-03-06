﻿//Reginald Ashman 2015
using UnityEngine;
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
            Player thePlayer = other.collider.GetComponent<Player>();
            if (!thePlayer.ShieldEnabled)
            {
                other.collider.GetComponent<Player>().PlayerDeath();
            }
            else
            {
                gameObject.SetActive(false);
            }
            
        }
    }
}