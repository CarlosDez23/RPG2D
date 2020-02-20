using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class StartUp : MonoBehaviour
{

    //const int numeroEscena = 0;
    public static bool primeraLlamada = true;
    
    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        DatosJugador datos = SistemaGuardado.cargarPartida(); 
        string escena = datos.escena; 
        SceneManager.LoadScene(escena);
        GameObject go = GameObject.Find("Player");

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void empezarJuego()
    {
        //Aquí vamos a cargar la partida si la hay
    }
}
