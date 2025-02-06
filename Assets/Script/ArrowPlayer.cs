using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GridBrushBase;

namespace Aether
{
    public class ArrowPlayer : MonoBehaviour
    {
        // Start is called before the first frame update

        public float speed;
        public Rigidbody2D myRigidbody2d;

        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }


        public void SetUp(Vector2 velocity, Vector3 direction) { 
            myRigidbody2d.velocity = velocity.normalized*speed;
            Debug.Log(direction);

            Vector3 rotationDirection;
            if (velocity == Vector2.up)
            {

                rotationDirection = new Vector3(0, 0, 90);


            }
            else if (velocity == Vector2.left)
            {
                rotationDirection = new Vector3(0, 0, 180);

            }
            else if (velocity == Vector2.down)
            {
                rotationDirection = new Vector3(0, 0, -90);
            }
            else if (velocity == new Vector2(1, 1)) {
                rotationDirection = new Vector3(0, 0, 45);
            }
            else if (velocity == new Vector2(-1, 1))
            {
                rotationDirection = new Vector3(0, 0, 135);
            }
            else if (velocity == new Vector2(-1, -1))
            {
                rotationDirection = new Vector3(0, 0, -135);
            }
            else if (velocity == new Vector2(1, -1))
            {
                rotationDirection = new Vector3(0, 0, -45);
            }
            else
            {
                rotationDirection = new Vector3(0, 0, 0);
            }


            transform.rotation = Quaternion.Euler(rotationDirection);


        }
        public void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Enemy")) { 
            
            Destroy(this.gameObject);
            }
        }
    }

}
