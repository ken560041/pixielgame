using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aether
{
    public class BoundedNPC : Chat
    {
        // Start is called before the first frame update

        private Vector3 directionVector3;
        private Transform myTransform;

        public float speed;
        private Rigidbody2D myRigidbody;
        private Animator anim;
        public Collider2D bounds;
        public float minmoveTime;
        public float maxmoveTime;
        private float moveTimeSeconds;
        public float minwaitTime;
        public float maxwaitTime;
        private float waitTimeSeconds;

        private bool isMoving;
        private void Start(){

            moveTimeSeconds = Random.Range(minmoveTime, maxmoveTime);  
            waitTimeSeconds=Random.Range(minwaitTime, maxwaitTime); 

            myTransform = GetComponent<Transform>();
            myRigidbody = GetComponent<Rigidbody2D>();
            anim = GetComponent<Animator>();
            ChangerDirection();
        }

        // Update is called once per frame

        
        public override void  Update()
        {
            base.Update();
            if (isMoving)
            {

                moveTimeSeconds -= Time.deltaTime;
                if (moveTimeSeconds <= 0)
                {
                    moveTimeSeconds = Random.Range(minmoveTime, maxmoveTime);
                    isMoving = false;
                    ChooseDifDirection();
                }
                if (!playerInRange)
                {
                    Move();
                }

            }
            else {

                waitTimeSeconds -= Time.deltaTime;
                if (waitTimeSeconds <= 0) {
                    isMoving = true;
                    waitTimeSeconds = Random.Range(minwaitTime, maxwaitTime);

                
                
                }

            
            }

            
        }

        private void ChooseDifDirection() {

            Vector3 temp = directionVector3;
            ChangerDirection();
            int loop = 0;
            while (temp == directionVector3 && loop < 100)
            {
                loop++;
                ChangerDirection();
            }
        }


        private void Move() {
            Vector3 temp = myTransform.position + directionVector3 * speed * Time.deltaTime;
            if (bounds.OverlapPoint(temp)) { 
                myRigidbody.MovePosition(temp);
            }
            else
            {

                ChangerDirection();
            }
            
        }

        void UpdateAnimation() {
            anim.SetBool("isMove", true);
            anim.SetFloat("MoveX", directionVector3.x);
            anim.SetFloat("MoveY", directionVector3.y);
        }

        void ChangerDirection() {
            int direction = Random.Range(0, 4);

            switch(direction)
            {

                case 0:
                    directionVector3 = Vector3.right;
                    break;

                case 1:
                    directionVector3 = Vector3.up;
                    break;
                case 2:
                    directionVector3 = Vector3.left;
                    break;
                case 3:
                    directionVector3 = Vector3.down;
                    break;
                default:
                    break;
            }
            UpdateAnimation();
        
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
           ChooseDifDirection();
        }

    }
}
