using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Inventario : ScriptableObject
{
    public Objeto objeto;
    public List<Objeto> listaObjetos = new List<Objeto>();
    public int llaves;

    public void addObjeto(Objeto objeto)
    {
        if (objeto.llave)
        {
            llaves++;
        }
        else
        {
            if (!listaObjetos.Contains(objeto))
            {
                listaObjetos.Add(objeto);
            }
        }
    }
}

