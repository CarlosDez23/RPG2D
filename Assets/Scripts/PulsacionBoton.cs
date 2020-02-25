using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PulsacionBoton : MonoBehaviour
{
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void comprobar(int opcion){

        switch(opcion)
        {
            case 1:
                //Nueva partida
                SistemaGuardado.borrarPartida();
                SistemaGuardadoCofres.borrarPartida();
                SceneManager.LoadScene(1);
                break;
            case 2: 
                //Para las opciones de cargar y reintentar
                CargarJuego.cargar();
                break;
            case 3:
                //La opción de salir nos lleva al menú principal
                SceneManager.LoadScene(0);
                break;
            default:
                break;
        }
    }
}
