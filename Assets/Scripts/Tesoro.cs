using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tesoro : MonoBehaviour
{
    public Objeto contenido;
    public Inventario inventarioJugador;
    public bool abierto;
    public Signal lanzarSignalObjeto;
    public bool enRango;
    
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("Player") && !other.isTrigger)
        {
            enRango = true; 
            if (!abierto)
            {
                abrirCofre();
                
            }else
            {
                cofreAbierto();
            }
        }
    }

    public void abrirCofre()
    {
        inventarioJugador.objeto = contenido;
        lanzarSignalObjeto.raise();
        abierto = true;  
    }

    public void cofreAbierto()
    {

    }
}
