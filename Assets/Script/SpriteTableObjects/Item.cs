using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aether
{
    [CreateAssetMenu]
    public class Item : ScriptableObject
    {
        // Start is called before the first frame update
        public Sprite itemSprite;
        public string itemDescription;
        public bool isKey;
    }
}
