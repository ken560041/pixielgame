using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
namespace Aether
{
    public class SignalListennel : MonoBehaviour
    {
        public Signaler signal;
        public UnityEvent signalEvent;
        public void OnSignalRaise() { 
            signalEvent.Invoke();
        
        }

        public void OnEnable() {

            signal.RegisterListener(this);
        }


        public void OnDisable() { 
        
            signal.UnRegisterListener(this);
        }
    }
}
