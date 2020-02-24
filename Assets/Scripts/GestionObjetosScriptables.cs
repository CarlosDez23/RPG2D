using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class GestionObjetosScriptables : MonoBehaviour
{
    public ScriptableObject corazones;

    void OnEnable()
    {
        cargarCorazones();
    }

    void OnDisable()
    {
        guardarCorazones();
    }

    public void guardarCorazones()
    {
        FileStream file = File.Create(Application.persistentDataPath +
            string.Format("/{0}.dat", corazones));
        BinaryFormatter binary = new BinaryFormatter();
        var json = JsonUtility.ToJson(corazones);
        binary.Serialize(file, json);
        file.Close();
    }

    public void cargarCorazones()
    {
        if (File.Exists(Application.persistentDataPath +
            string.Format("/{0}.dat", corazones)))
        {
            FileStream file = File.Open(Application.persistentDataPath +
                string.Format("/{0}.dat", corazones), FileMode.Open);
            BinaryFormatter binary = new BinaryFormatter();
            JsonUtility.FromJsonOverwrite((string)binary.Deserialize(file),
                corazones);
            file.Close();
        }
    }
    public void borrarDatos()
    {

        if (File.Exists(Application.persistentDataPath +
            string.Format("/{0}.dat", corazones)))
        {
            File.Delete(Application.persistentDataPath +
                string.Format("/{0}.dat", corazones));
        }

    }
}
