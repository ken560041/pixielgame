using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aether
{
    public class Context : MonoBehaviour
    {
        // Start is called before the first frame update

        public GameObject context;
        public bool contextActive=false;

        
      /*  public void Enable() { 
            context.SetActive(true);
            *//*if (context != null)
            {
                context.GetComponent<Animator>().SetBool("Context", true);
            }*//*
        }
        public void Disable() {
            context.GetComponent<Animator>().SetBool("Destroy", true);
            context.SetActive(false);
            
        }*/

        public void ChangeContext()
        {
            contextActive=!contextActive;
            if (contextActive)
            {
                context.SetActive(true);
            }
            else {
                context.GetComponent<Animator>().SetBool("Destroy", true);
                context.SetActive(false);
                
            }
        }
    }
}
