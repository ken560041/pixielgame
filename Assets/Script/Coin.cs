using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
namespace Aether
{
    public class Coin : Powerup
    {
        // Start is called before the first frame update

        public Inventory playerInventory;
        void Start()
        {
            powerUpSignal.Raise();
        }

        // Update is called once per frame
        void Update()
        {
        
        }
        public void OnTriggerEnter2D(Collider2D collision)
        {
            playerInventory.coins += 1;
                powerUpSignal.Raise();
                Destroy(this.gameObject);
            
        }
    }
}
