using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aether
{
    public class Interactable : MonoBehaviour
    {
        // Start is called before the first frame update

        public bool playerInRange;
        public Signaler context;
       
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player") && !collision.isTrigger)
            {
                context.Raise();
                playerInRange = true;
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.CompareTag("Player") && !collision.isTrigger)
            {
                context.Raise();
                playerInRange = false;
                
            }
        }
    }
}
