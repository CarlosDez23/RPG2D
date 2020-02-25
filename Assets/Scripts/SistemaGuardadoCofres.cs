using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SistemaGuardadoCofres
{
    public static void guardarEstadoCofres(bool[] cofres)
    {
        FileStream stream = null;
        try
        {
            BinaryFormatter formatter = new BinaryFormatter();
            //Con persistent data path accedemos a la persistencia de cualquier sistema operativo
            string ruta = Application.persistentDataPath + "/estadocofres.data";
            stream = new FileStream(ruta, FileMode.Create);
            formatter.Serialize(stream, cofres);
            Debug.Log("Guardado correctamente"); 
        }
        catch (IOException)
        {
            Debug.Log("No ha guardado");
        }
        finally
        {
            stream.Close();
        }
    }

    public static bool[] cargarDatosCofres()
    {
        bool[] cofres = null;
        string ruta = Application.persistentDataPath + "/estadocofres.data";
        if (File.Exists(ruta))
        {
            FileStream stream = null;
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                stream = new FileStream(ruta, FileMode.Open);
                cofres = formatter.Deserialize(stream) as bool[];
                Debug.Log("Leído fichero cofres");
            }
            catch (IOException)
            {
                Debug.Log("No ha cargado");
            }
            finally
            {
                stream.Close();
            }
        }
        return cofres;
    }

    public static void borrarPartida()
    {
        string ruta = Application.persistentDataPath + "/estadocofres.data";
        if (File.Exists(ruta))
        {
            File.Delete(ruta);
        }
    }
}
