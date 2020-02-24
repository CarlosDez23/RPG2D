using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PulsacionBoton : MonoBehaviour
{
    public GameObject herramientaBorrado;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void comprobar(int opcion){

        switch(opcion){
            case 1://nueva partida, ir a nivel uno
                //herramientaBorrado.borrarDatos();
                Instantiate(herramientaBorrado);
                herramientaBorrado.GetComponent<GestionObjetosScriptables>().borrarDatos();
                SistemaGuardado.borrarPartida();
                SceneManager.LoadScene(1);
                break;
            case 2: //cargar partida y reintentar
                herramientaBorrado.GetComponent<GestionObjetosScriptables>().cargarCorazones();
                CargarJuego.cargar();
                break;
            case 3://salir -> inicio
                SceneManager.LoadScene(0);
                break;

        }
    }


}
