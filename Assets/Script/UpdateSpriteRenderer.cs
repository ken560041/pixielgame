using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aether
{
    public class UpdateSpriteRenderer : MonoBehaviour
    {
        // Start is called before the first frame update
        public Sprite newSprite;

        private SpriteRenderer spriteRenderer;
        Door door;
        public  Collider2D colliderkeydoor;
        void Start()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            
            newSprite = Resources.Load<GameObject>("Images/NinjaAdventure/Backgrounds/Tilesets/NewTilesetHouse/TilesetReliefDetail_17").GetComponent<SpriteRenderer>().sprite;
            door=GameObject.Find("TriggerArea").GetComponent<Door>();
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (door.playerInRange && door.doorType == DoorType.key)
                    spriteRenderer.sprite = newSprite;
                    colliderkeydoor.enabled = false;
            }
        }
    }
}
