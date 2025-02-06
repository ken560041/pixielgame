using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Aether
{

    public enum DoorType { 
    
    key,
    enemy,
    button

    }
    public class Door : Interactable
    {
        // Start is called before the first frame update
        public Sprite temp;
        [Header("Door variables")]
        public DoorType doorType;
        public bool open=false;
        public Inventory playerInventory;
        public SpriteRenderer doorSpriteRenderer;
        public BoxCollider2D physicsCollider;
        GameObject lookDoor1;
        


        // Update is called once per frame
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (playerInRange && doorType == DoorType.key)
                {

                    if (playerInventory.numberOfKeys > 0)
                    {

                        playerInventory.numberOfKeys--;
                        Open();

                    }


                }
            }

        }
        

        public void Open() {
           // doorSpriteRenderer.sprite = null;
            /*temp = Resources.Load<Sprite>("Images/NinjaAdventure/Items/Weapons/Bow/Arrow");
            doorSpriteRenderer.GetComponent<SpriteRenderer>().sprite = temp;*/
            /*doorSpriteRenderer.enabled = false;*/

            open = true;

            
        }
    }
}
