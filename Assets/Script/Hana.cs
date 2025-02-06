using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aether
{
    public class Hana : MonoBehaviour
    {
        // Start is called before the first frame update
        private Animator anim;

        void Start()
        {
            anim = GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        public void Smash()
        {
            anim.SetBool("Destroy", true);
        }
        IEnumerator breackCo() {
            yield return new WaitForSeconds(0.3f);
            this.gameObject.SetActive(false);
        }
    }
}
