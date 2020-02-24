using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class CargarJuego
{

    public static void cargar()
    {
        DatosJugador datos = SistemaGuardado.cargarPartida();
        if (datos != null)
        {
            string escena = datos.escena;
            SceneManager.LoadScene(escena);
        }
    }
}
