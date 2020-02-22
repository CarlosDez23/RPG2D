using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SignalListener : MonoBehaviour
{
    public Signal signal;
    public UnityEvent signalEvent; 

    public void onSignalRaised()
    {
        signalEvent.Invoke();
    }

    private void OnEnable() 
    {
        signal.addListener(this);
    }

    private void OnDisable()
    {
        signal.borrarListener(this); 
    }
}
