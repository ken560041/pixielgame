using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aether
{

    [CreateAssetMenu]
    public class Signaler : ScriptableObject

    {
        // Start is called before the first frame update
        public List<SignalListennel> listennel=new List<SignalListennel>();
        public void Raise()
        {
            for(int i=listennel.Count-1; i>=0; i--)
            {
                listennel[i].OnSignalRaise();
            }

        }

        public void RegisterListener(SignalListennel listener) { 
        
            listennel.Add(listener);
        }

        public void UnRegisterListener(SignalListennel listener)
        {

            listennel.Remove(listener);
        }
    }
}
