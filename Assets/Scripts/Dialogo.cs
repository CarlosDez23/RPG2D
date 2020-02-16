using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class Dialogo : MonoBehaviour
{
    public GameObject cajaDialogo;
    public Text textoDialogo; 
    public string texto;
    public bool activo; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space) && activo)
        {
            if (cajaDialogo.activeInHierarchy)
            {
                cajaDialogo.SetActive(false);
            }else
            {
                cajaDialogo.SetActive(true); 
                textoDialogo.text = texto; 
            }
        }
    }

    //Cuando el jugador dispare el trigger del cartel 
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("Player"))
        {
            //Mostramos el diálogo
            activo = true; 
        }
    }

    void OnTriggerExit2D(Collider2D other) 
    {
        if (other.tag.Equals("Player"))
        {
            activo = false; 
            cajaDialogo.SetActive(false);
        }
    }
}
