using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PasoANivel2 : MonoBehaviour
{
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("Player") && other.GetComponent<MovimientoPersonaje>().llaves == 6)
        {
            SceneManager.LoadScene("Nivel2");
        }
    }
}
