﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolpeAlien : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag.Equals("Player"))
        {
            //print("jugador golpeado");
            other.GetComponent<MovimientoPersonaje>().getHit(1.0f); 
        }
    }
}