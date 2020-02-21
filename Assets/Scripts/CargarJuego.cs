using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CargarJuego
{
    public static GameObject player; 

  //[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    static void cargar()
    {
        Debug.Log("Ha pasado a cargar");
        DatosJugador datos = SistemaGuardado.cargarPartida();
        if (datos != null)
        {
            Debug.Log(datos.escena.ToString()+" "+datos.vidas+" "+datos.llaves+" "+datos.posicion[0]);
            string escena = datos.escena;
            SceneManager.LoadScene(escena);
            player = GameObject.FindGameObjectWithTag("Player");
            Debug.Log(player.tag);
            player.GetComponent<MovimientoPersonaje>().cargarPersonaje(datos);
        }
    }
}
