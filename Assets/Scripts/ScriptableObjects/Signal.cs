using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Signal : ScriptableObject
{
    public List<SignalListener> listeners = new List<SignalListener>();

    public void raise()
    {
        for (int i = listeners.Count - 1; i >= 0; i--)
        {
            listeners[i].onSignalRaised();
        }
    }
 
    public void addListener(SignalListener listener)
    {
        listeners.Add(listener);
    }

    public void borrarListener(SignalListener listener)
    {
        listeners.Remove(listener); 
    }
}
