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
    //Necesario para la interfaz móvil
    public JoyButton joyButton;

 

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Space) || joyButton.pulsado) && enRango)
        {
            if (!abierto)
            {
                abrirCofre();
            }
            else
            {
                cofreAbierto();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("Player") && !other.isTrigger)
        {
            enRango = true;
        }
    }

    public void abrirCofre()
    {
        abierto = true;
        inventarioJugador.addObjeto(contenido);
        inventarioJugador.objeto = contenido;
        lanzarSignalObjeto.raise();
        animator.SetBool("abierto",true); 
        StartCoroutine(borrarCofre());
    }

    
    public void cofreAbierto()
    {
        lanzarSignalObjeto.raise();
    }
    

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag.Equals("Player") && !other.isTrigger && !abierto)
        {
            enRango = false;
        }
    }

    IEnumerator borrarCofre()
    {
        yield return new WaitForSeconds(2f);
        this.gameObject.SetActive(false);
        Destroy(this, 0.5f); 
    }
}
