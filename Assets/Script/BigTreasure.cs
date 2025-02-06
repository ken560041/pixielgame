using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Aether
{
    public class BigTreasure : Interactable
    {
        // Start is called before the first frame update
        public Item item;
        public Inventory playerInventory;
        public bool isOpen;
        public Signaler raiseItem;
        public GameObject dialogBox;
        public Text dialogText;
        private Animator anim;

        void Start()
        {
        anim = GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {

            if (Input.GetKeyDown(KeyCode.Space) && playerInRange)
            {

                if(!isOpen)
                {

                    OpenChest();
                }
                else
                {
                    ChestAlreadyOpen();
                }
            }
        }
        public void OpenChest() {

            //Dialog window on
            dialogBox.SetActive(true);

            dialogText.text = item.itemDescription;



            playerInventory.AddItem(item); 

            playerInventory.currentItem = item;
            
            raiseItem.Raise();
            
           

            context.Raise();

            isOpen=true;
        }

        public void ChestAlreadyOpen() {
           

                dialogBox.SetActive(false);

             //   playerInventory.currentItem = null;

                raiseItem.Raise();
            
        
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player") && !collision.isTrigger && !isOpen)
            {
                context.Raise();
                playerInRange = true;
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.CompareTag("Player") && !collision.isTrigger )
            {
                context.Raise();
                playerInRange = false;

            }
        }
    }
}
