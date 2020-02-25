using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionCofresAbiertos : MonoBehaviour
{
    public GameObject[] listaCofresenMapa;
    private bool[] estado;
    // Start is called before the first frame update
    void Start()
    {
        actualizarEstado();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void actualizarEstado()
    {
        estado = SistemaGuardadoCofres.cargarDatosCofres();
        if (estado == null)
        {
            Debug.Log("No ha devuelto nada");
        }
        for (int i = 0; i < estado.Length; i++)
        {
            Debug.Log(estado[i]);
        }
    
        for (int i = 0; i < listaCofresenMapa.Length; i++)
        {
            if (!estado[i])
            {
                listaCofresenMapa[i].SetActive(false);
            }
        }
    }

    public void guardar()
    {
        Debug.Log("Paso a guardar");
        bool[] estadoCofres = new bool[listaCofresenMapa.Length];
        for (int i = 0; i < listaCofresenMapa.Length; i++)
        {
            if (!listaCofresenMapa[i].activeSelf)
            {
                estadoCofres[i] = false;
            }else
            {
                estadoCofres[i] = true;
            }
        }
        SistemaGuardadoCofres.guardarEstadoCofres(estadoCofres);    
    }
}
