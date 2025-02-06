using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aether
{
    public class Projectitle : MonoBehaviour
    {
        // Start is called before the first frame update

        [Header("Movement Stuff")]
        public float moveSpeed;
        public Vector2 directionToMove;

        [Header("Life Time")]
        public float lifetime;
        public float lifetimeSeconds;
        public Rigidbody2D myRigidbody;

        void Awake()
        {
            myRigidbody = GetComponent<Rigidbody2D>();
            lifetimeSeconds = lifetime;
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            lifetimeSeconds =lifetimeSeconds-Time.deltaTime;
            if (lifetimeSeconds <= 0)
            {
                Destroy(this.gameObject);
            }
        }

        public void Lanch(Vector2 initialVec)
        {

            myRigidbody.velocity= initialVec.normalized*moveSpeed;
        }

        public void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                Destroy(this.gameObject);
            }
        }
    }
}
