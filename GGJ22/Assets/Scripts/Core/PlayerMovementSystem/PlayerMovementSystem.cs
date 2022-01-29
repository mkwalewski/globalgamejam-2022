using UnityEngine;

namespace Core
{
    public class PlayerMovementSystem : MonoBehaviour
    {
        [SerializeField]
        private CharacterController controller;
        
        [SerializeField]
        private float speed;

        private Vector3 direction;
        private float jumpForce = 10f;
        private float gravity = -20f;
        
        public void UpdateMovement(InputSystem inputSystem)
        {
            float horizontalValue = inputSystem.GetHorizontalInput();
            direction.x = horizontalValue * speed;
            direction.y += gravity * Time.deltaTime;

            if (controller.isGrounded && inputSystem.IsJumpClicked())
            {
                direction.y = jumpForce;
            }
            
            controller.Move(direction * Time.deltaTime);
        }
    }
}