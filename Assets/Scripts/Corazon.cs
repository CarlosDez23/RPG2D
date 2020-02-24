using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corazon : MonoBehaviour
{
    public Signal signalCorazon; 
    public FloatValue saludJugador;
    public float valorCorazon;
    public FloatValue contenedorCorazones;
    
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
            saludJugador.valorEnEjecucion += valorCorazon;
            if (saludJugador.valorInicial > contenedorCorazones.valorEnEjecucion * 2)
            {
                saludJugador.valorInicial = contenedorCorazones.valorEnEjecucion * 2;
            } 
            signalCorazon.raise(); 
            StartCoroutine(destruirCorazon());
        }
    }

    IEnumerator destruirCorazon()
    {
        yield return new WaitForSeconds(.3f);
        Destroy(this.gameObject);
    }
}
