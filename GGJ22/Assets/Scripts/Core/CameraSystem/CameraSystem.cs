using System;
using UnityEngine;

namespace Core
{
    public class CameraSystem : MonoBehaviour
    {
        [SerializeField]
        private Camera camera;
        
        [SerializeField]
        private PlayerMovementSystem playerMovementSystem;

        private float speed = 0.15f;
        private Vector3 offset;
        
        public void StartCamera()
        {
            offset = camera.transform.position - playerMovementSystem.transform.position;
        }
        
        public void UpdateCamera()
        {
            Vector3 newPosition = playerMovementSystem.transform.position + offset;
            camera.transform.position = Vector3.Lerp(camera.transform.position, newPosition, speed);
        }
    }
}