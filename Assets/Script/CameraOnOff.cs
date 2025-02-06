using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

namespace Aether
{
    public class CameraOnOff : MonoBehaviour
    {
        // Start is called before the first frame update
        public PolygonCollider2D roomCollider; // Tham chiếu đến PolygonCollider2D của phòng
        public GameObject virtualCamera; // Tham chiếu đến CinemachineVirtualCamera
        private void Start()
        {
       
        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player")&& !other.isTrigger)
            {
                virtualCamera.SetActive(true);
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Player") && !other.isTrigger)
            {
                virtualCamera.SetActive(false); // Tắt CinemachineVirtualCamera
            }
        }
        
    }
}
