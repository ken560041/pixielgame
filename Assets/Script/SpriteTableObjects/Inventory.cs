using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aether
{
    [CreateAssetMenu]
    public class Inventory : ScriptableObject
    {
        // Start is called before the first frame update
        public Item currentItem;
        public List<Item> items=new List<Item>();
        public int numberOfKeys;

        public int coins;


        public void AddItem(Item itemAdd) {

            if (itemAdd.isKey) { 
            
                numberOfKeys++;
            }
            else
            {
                if(!items.Contains(itemAdd) ){
                
                items.Add(itemAdd);}

            }
        }
    }
}
