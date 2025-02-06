using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace Aether
{
    public class SceneSwitcher : MonoBehaviour
    {
        // Start is called before the first frame update
        public string sceneToLoad;
        public Vector2 playerPosition;
        public VectorValues playerValues;

        public GameObject fadeInPanel;
        public GameObject fadeOutPanel;

        public float fadeWait;
        private void Awake()
        {
            if (fadeInPanel != null) {
                GameObject panel=Instantiate(fadeInPanel, Vector3.zero,Quaternion.identity) as GameObject;
                Destroy(panel, 0.4f);
            }
        }
        public void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player") && !collision.isTrigger) {
                playerValues.initialValues = playerPosition;
                //SceneManager.LoadScene(sceneToLoad);
                StartCoroutine(FadeCo());
            }
        }

        public IEnumerator FadeCo()
        {
            if (fadeOutPanel != null)
            {
                Instantiate(fadeOutPanel, Vector3.zero, Quaternion.identity);
            }

            yield return new WaitForSeconds(fadeWait);

            AsyncOperation asyncOperation=SceneManager.LoadSceneAsync(sceneToLoad);
            while(!asyncOperation.isDone)
            {

                yield return null;
            }
        }
    }
}
