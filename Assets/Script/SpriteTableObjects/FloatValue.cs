using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aether
{
    [CreateAssetMenu]
    public class FloatValue : ScriptableObject, ISerializationCallbackReceiver
    {
        // Start is called before the first frame update
        public float initValue;

        [HideInInspector]
        public float RuntimeValue;
        public void OnAfterDeserialize() { 
            RuntimeValue = initValue;
        }
        public void OnBeforeSerialize() { }
    }
}
