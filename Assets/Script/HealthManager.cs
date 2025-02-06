using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Aether
{
    public class HealthManager : MonoBehaviour
    {
        // Start is called before the first frame update
        public Image[] hearts;
        public Sprite fullHearts;
        public Sprite halfHearts1;
        public Sprite halfHearts2;
        public Sprite halfHearts3;
        public Sprite emptyHearts;

        public FloatValue heartsContainers;
        public FloatValue playerHearts;
        void Start()
        {
            InitHearts();
        }

        // Update is called once per frame
        void Update()
        {
        
        }


        public void InitHearts() {
            for (int i = 0; i < heartsContainers.initValue; i++) {

                hearts[i].gameObject.SetActive(true);
                hearts[i].sprite = fullHearts;
            }
        }


        public void updateHearts() {

            float tempHearts = playerHearts.RuntimeValue / 2;
            for (int i = 0; i < heartsContainers.initValue; i++) {
                if (i <= tempHearts-1) {

                    hearts[i].sprite = fullHearts;
                }
                else if(i>=tempHearts)
                {

                    hearts[i].sprite=emptyHearts;
                }
                else {
                    hearts[i].sprite=halfHearts2;
                }
            
            }

        }
    }
}
