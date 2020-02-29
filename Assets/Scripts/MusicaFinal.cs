using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicaFinal : MonoBehaviour
{

     public AudioSource sonidoPrincipal;

     public AudioSource sonidoFinal;
     public bool escaleras;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("Player") && other.GetComponent<MovimientoPersonaje>().llaves == 13)
        {
            
            if(escaleras){
                sonidoPrincipal.Stop();
                sonidoFinal.Play();
            }else{
                sonidoFinal.Stop();
                sonidoPrincipal.Play();
            }
        }
    }
}
