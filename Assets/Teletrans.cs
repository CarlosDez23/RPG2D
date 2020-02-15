using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teletrans : MonoBehaviour
{
    public GameObject objetivo; 

 
    void Awake()
    {
        //Ocultamos los colisionadaores
        GetComponent<SpriteRenderer>().enabled = false;
        transform.GetChild(0). GetComponent<SpriteRenderer>().enabled = false;
        
    }
    void Start()
    {
        
    }

   
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Player")
        {
            other.transform.position = objetivo.transform.GetChild(0).transform.position; 
        }
    }
}
