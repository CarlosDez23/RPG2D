using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corazon : MonoBehaviour
{
    
    void Start()
    {
        
    }

   
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("Player"))
        {
            if (!(other.GetComponent<MovimientoPersonaje>().vidas == 5))
            {
                other.GetComponent<MovimientoPersonaje>().vidas++;
            }
            
            StartCoroutine(destruirCorazon());
        }
    }

    IEnumerator destruirCorazon()
    {
        yield return new WaitForSeconds(.3f);
        Destroy(this.gameObject);
    }
}
