using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolpeJugador : MonoBehaviour
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
        if (other.tag.Equals("rompible"))
        {
            other.GetComponent<Jarron>().destruirJarron(); 
        }

        if (other.tag.Equals("enemigo"))
        {
            other.GetComponent<MovimientoAlien>().golpeado(); 
        }
    }
}
