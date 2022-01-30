using System;
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
        private bool isDuality;
        private float jumpForce = 10f;
        private float gravity = -10f;
        private float gravityScale = 1f;

        public void UpdateMovement(InputSystem inputSystem)
        {
            float horizontalValue = inputSystem.GetHorizontalInput();

            if (inputSystem.IsDualityClicked())
            {
                isDuality = !isDuality;
                gravityScale *= -1;
            }
            
            animator.SetFloat("speed", Mathf.Abs(horizontalValue));
            animator.SetBool("isGrounded", controller.isGrounded);
            direction.x = horizontalValue * speed;
            direction.y += gravity * gravityScale * Time.deltaTime;

            if (controller.isGrounded && inputSystem.IsJumpClicked())
            {
                direction.y = jumpForce;
            }

            if (horizontalValue != 0)
            {
                // Vector3 newDirection = new Vector3(horizontalValue, 0, 0);
                // Quaternion newRotation = Quaternion.LookRotation(newDirection);
                // model.rotation = newRotation;
            }

            if (isDuality)
            {
                float sign = Mathf.Sign(horizontalValue);
                Quaternion toRotation = Quaternion.Euler(0, sign * 90, 180);
                model.rotation = Quaternion.Lerp(model.rotation, toRotation, speed * Time.deltaTime);
            }
            else
            {
                float sign = Mathf.Sign(horizontalValue);
                Quaternion toRotation = Quaternion.Euler(0, sign * 90, 0);
                model.rotation = Quaternion.Lerp(model.rotation, toRotation, speed * Time.deltaTime);
            }
            
            controller.Move(direction * Time.deltaTime);
        }
    }
}