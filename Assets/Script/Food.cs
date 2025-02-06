using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aether
{
    public class Food : Powerup
    {
        // Start is called before the first frame update
        public FloatValue playerHealth;
        public FloatValue healthCo;



        public float amountToIncrese;
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }
        public void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player") && !collision.isTrigger)
            {
                playerHealth.RuntimeValue += amountToIncrese;
                if (playerHealth.RuntimeValue > healthCo.RuntimeValue * 2) { 
                
                    playerHealth.RuntimeValue = healthCo.RuntimeValue * 2;
                }
                powerUpSignal.Raise();
                Destroy(this.gameObject);
            }
        }
    }
}
