using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
[System.Serializable]
public class FloatValue : ScriptableObject//, ISerializationCallbackReceiver
{
   public float valorInicial;

   public float valorEnEjecucion;

   /*
   public void OnAfterDeserialize()
   {
      valorEnEjecucion = valorInicial;
   }
 
   public void OnBeforeSerialize()
   {
   }
   */
}
