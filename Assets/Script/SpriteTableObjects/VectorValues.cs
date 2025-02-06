using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aether
{
    [CreateAssetMenu]
    public class VectorValues : ScriptableObject,ISerializationCallbackReceiver
    {
        public Vector2 initialValues;
        public Vector2 defaultValues;
        public void OnAfterDeserialize()
        {
            initialValues = defaultValues;
        }
        public void OnBeforeSerialize() { }
    }
}
