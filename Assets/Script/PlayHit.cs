using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aether
{
    public class PlayHit : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Object") ){
                collision.GetComponent<Hana>().Smash();
            }
        }
    }
}
