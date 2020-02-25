using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraVida : MonoBehaviour
{
    public GameObject personaje;
    private int salud;
    private int numeroCorazones;
    public Image[] corazones;
    public Sprite corazonLleno;
    public Sprite corazonVacio; 

    void Start()
    {
        numeroCorazones = 5; 
    }

    void Update()
    {
        salud = personaje.GetComponent<MovimientoPersonaje>().vidas;
        if (salud > numeroCorazones)
        {
            salud = numeroCorazones;
        }

        for (int i = 0; i < corazones.Length; i++)
        {
            if (i < salud)
            {
                corazones[i].sprite = corazonLleno;
            }else
            {
                corazones[i].sprite = corazonVacio; 
            }
        }
    }
}
