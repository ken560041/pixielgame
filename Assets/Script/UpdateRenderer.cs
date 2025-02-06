using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Aether
{
    public class UpdateRenderer : MonoBehaviour { 

        public Collider2D upHitbox;
        public Collider2D downHitbox;
        public Collider2D leftHitbox;
        public Collider2D rightHitbox;
        public SpriteRenderer up;
        public SpriteRenderer down;
        public SpriteRenderer left;
        public SpriteRenderer right;

        public PlayerMovement playerMovement;
        public String spriteResourcesPath="Images/NinjaAdventure/Items/Weapons/Axe/Sprite";

        public Vector2 momenvt;
        Sprite newSprite;
        // Start is called before the first frame update
        void Start()
        {
             newSprite = Resources.Load<Sprite>(spriteResourcesPath);
        playerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();
            up = upHitbox.gameObject.GetComponent<SpriteRenderer>();
            down=downHitbox.gameObject.GetComponent<SpriteRenderer>();
            left=leftHitbox.gameObject.GetComponent<SpriteRenderer>();
            right=rightHitbox.gameObject.GetComponent<SpriteRenderer>();
        }

        // Update is called once per frame
        void Update()
        {
            momenvt.x = playerMovement.animator.GetFloat("Horizontal");
            momenvt.y = playerMovement.animator.GetFloat("Vertical");

            if (playerMovement.currentState==global::PlayerState.attack&& playerMovement.animator.GetBool("IsAttack") ){
                //&& playerMovement.currentState!=global::PlayerState.attack) { 

                StartCoroutine(Rendererhitbox(momenvt.x,momenvt.y));


            }
            

        }
        private IEnumerator Rendererhitbox(float x, float y) {


             
            if (x == 1)
            {

                right.sprite = newSprite;
                Vector3 currentEulerAngles = up.transform.eulerAngles;
                right.transform.eulerAngles = new Vector3(currentEulerAngles.x, currentEulerAngles.y, currentEulerAngles.z -90f);
                yield return new WaitForSeconds(.25f);
                
                right.sprite = null; 
            }
            else if (x == -1)
            {

                left.sprite = newSprite;
                Vector3 currentEulerAngles = up.transform.eulerAngles;
                left.transform.eulerAngles = new Vector3(currentEulerAngles.x, currentEulerAngles.y, currentEulerAngles.z + 90f);
                yield return new WaitForSeconds(.25f);
                left.sprite = null;
            }
            else if (y == 1)
            {
                up.sprite = newSprite;
                Vector3 currentEulerAngles = up.transform.eulerAngles;
                up.transform.eulerAngles = new Vector3(currentEulerAngles.x, currentEulerAngles.y, currentEulerAngles.z + 0f);
                yield return new WaitForSeconds(.25f);
                
                up.sprite = null;
            }
            else if (y == -1) { 
            
                down.sprite = newSprite;
                Vector3 currentEulerAngles = up.transform.eulerAngles;
                down.transform.eulerAngles = new Vector3(currentEulerAngles.x, currentEulerAngles.y, currentEulerAngles.z + 180f);
                yield return new WaitForSeconds(.25f);
                down.sprite = null;
            }
            yield return null;
        }

        

    }
}

