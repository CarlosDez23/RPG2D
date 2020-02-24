
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SistemaGuardado
{
    //Método para guardar la partida 
    public static void guardarPartida(MovimientoPersonaje personaje, string escena)
    {
        FileStream stream = null; 
        try
        {
            BinaryFormatter formatter = new BinaryFormatter();
            //Con persistent data path accedemos a la persistencia de cualquier sistema operativo
            string ruta = Application.persistentDataPath + "/estadojugador.data";
            stream = new FileStream(ruta, FileMode.Create);
            DatosJugador datos = new DatosJugador(personaje, escena);
            formatter.Serialize(stream, datos);
           

        }catch(IOException)
        {
            Debug.Log("Fallo al guardar la partida");
        }
        finally
        {
            stream.Close();
        }
    }

    //Método para guardar la partida
    public static DatosJugador cargarPartida()
    {
        DatosJugador datos = null; 
        string ruta = Application.persistentDataPath + "/estadojugador.data";
        if (File.Exists(ruta))
        {
            FileStream stream = null;
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                stream = new FileStream(ruta, FileMode.Open); 
                datos =  formatter.Deserialize(stream) as DatosJugador;
                 
            }catch(IOException)
            {

            }
            finally
            {
                stream.Close();
            }
            
        }
        return datos;
    }

    public static void borrarPartida()
    {
        string ruta = Application.persistentDataPath + "/estadojugador.data";
        if (File.Exists(ruta))
        {
            File.Delete(ruta); 
        }
    }
}
