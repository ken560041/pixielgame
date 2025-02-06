using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aether
{
    public class CameraMovements : MonoBehaviour
    {
        // Start is called before the first frame update

        public Transform target;
        public float smoothing;
        public Vector2 maxPosition;
        public Vector2 minPosition;
        public Animator anima;
        void Start()
        {
        
        }

        // Update is called once per frame
        void LastUpdate()
        {
        if(transform.position!=target.position)
            {

                Vector3 targetPosition=new Vector3(target.position.x, target.position.y, transform.position.z);
                targetPosition.x = Mathf.Clamp(targetPosition.x, minPosition.x, maxPosition.x);
                targetPosition.y=Mathf.Clamp(targetPosition.y, minPosition.y, maxPosition.y);
                transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing);
            }
        }

        public void BeginKick() {

            anima.SetBool("kick_ativite", true);
            StartCoroutine(KichCo());
        }

        public IEnumerator KichCo() { 
        yield return null;
            anima.SetBool("kick_ativite", false);
        }
    }
}
