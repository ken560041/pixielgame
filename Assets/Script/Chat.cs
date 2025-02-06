using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Aether
{
    public class Chat : Interactable
    {
        // Start is called before the first frame update
        public GameObject dialogBox;
        public Text dialogText;
        public string dialog;
        
        void Start()
        {
        
        }

        // Update is called once per frame
        public virtual void  Update()
        {

            if(Input.GetKeyDown(KeyCode.Space)&& playerInRange) {

                if (dialogBox.activeInHierarchy) { 
                
                dialogBox.SetActive(false);
                }
                else
                {
                    dialogBox.SetActive(true);
                    dialogText.text = dialog;
                }
            }
        
        }

        /*private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player")&& !collision.isTrigger) {
                context.Raise();
                playerInRange = true;
            }
        }*/

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.CompareTag("Player")&& !collision.isTrigger) { 
                context.Raise();
                playerInRange=false;
                dialogBox.SetActive(false);
            }
        }
    }
}
