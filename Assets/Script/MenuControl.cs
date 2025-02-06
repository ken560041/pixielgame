using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Aether
{
    public class MenuControl : MonoBehaviour
    {
        // Start is called before the first frame update
        public void PlayGame() {

            SceneManager.LoadScene(0);
        }

        public void OutGame() { 
        
               Application.Quit();
        }
    }
}
