using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

namespace Aether
{
    public class PauseManager : MonoBehaviour
    {
        // Start is called before the first frame update

        private bool isPaused;
        public GameObject pausedPanel;

        void Start()
        {
            isPaused = true;
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetButtonDown("pause")) {
                ChangePause();
            }

        
        }
        public void ChangePause() {
            isPaused = !isPaused;
            if (isPaused)
            {
                pausedPanel.SetActive(true);
                Time.timeScale = 0f;
            }
            else
            {
                pausedPanel.SetActive(false);
                Time.timeScale = 1f;
            }

        }

        public void Resume()
        {


            isPaused = !isPaused;
           
        }

        public void QuitToMain() {
            SceneManager.LoadScene("MenuGame");
            Time.timeScale = 1.0f;
        }
    }
}
