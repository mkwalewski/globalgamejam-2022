using UnityEngine;

namespace Core
{
    public class PlayerMovementSystem : MonoBehaviour
    {
        [SerializeField]
        private CharacterController controller;

        [SerializeField]
        private Transform model;
        
        [SerializeField]
        private Animator animator;
        
        [SerializeField]
        private float speed;

        private Vector3 direction;
        private float jumpForce = 10f;
        private float gravity = -20f;
        
        public void UpdateMovement(InputSystem inputSystem)
        {
            float horizontalValue = inputSystem.GetHorizontalInput();
            animator.SetFloat("speed", Mathf.Abs(horizontalValue));
            animator.SetBool("isGrounded", controller.isGrounded);
            direction.x = horizontalValue * speed;
            direction.y += gravity * Time.deltaTime;

            if (controller.isGrounded && inputSystem.IsJumpClicked())
            {
                direction.y = jumpForce;
            }

            if (horizontalValue != 0)
            {
                Vector3 newDirection = new Vector3(horizontalValue, 0, 0);
                Quaternion newRotation = Quaternion.LookRotation(newDirection);
                model.rotation = newRotation;
            }
            
            controller.Move(direction * Time.deltaTime);
        }
    }
}