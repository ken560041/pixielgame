using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aether
{
    public class Room : MonoBehaviour
    {
        // Start is called before the first frame update
        public Enemy[] enemies;
        public bool isExit;


        public void Awake()
        {
            isExit = true;
        }
        public virtual void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player") && !collision.isTrigger&&isExit) { }

            isExit = false;
            for (int i = 0; i < enemies.Length; i++) {

                ChangeActivation(enemies[i],true);
                enemies[i].health = enemies[i].maxHealth.initValue;
            }  

        }


        public virtual void OnTriggerExit2D(Collider2D collision) {
            isExit = true;
            /*if (collision.gameObject.CompareTag("Player") && !collision.isTrigger) { }

            for (int i = 0; i < enemies.Length; i++)
            {

                ChangeActivation(enemies[i], false);
                
            }*/

        }

        void ChangeActivation(Component component,bool activation) { 
            component.gameObject.SetActive(activation);
            
        }
    }
}