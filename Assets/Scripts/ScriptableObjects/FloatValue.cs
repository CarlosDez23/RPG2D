using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class FloatValue : ScriptableObject, ISerializationCallbackReceiver
{
   public float valorInicial;

   [HideInInspector]
   public float valorEnEjecucion;

   public void OnAfterDeserialize()
   {
      valorEnEjecucion = valorInicial;
   }
 
   public void OnBeforeSerialize()
   {
   }
}
