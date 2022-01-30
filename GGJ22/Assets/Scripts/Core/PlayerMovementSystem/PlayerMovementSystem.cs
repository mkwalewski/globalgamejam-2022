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

        private Rigidbody rigidbody;
        private Vector3 direction;
        private float gravityScale = 1f;
        private const float globalGravity = -9.81f;
        private float jumpForce = 10f;
        private float gravity = -20f;

        public void StartMovement()
        {
            rigidbody = GetComponent<Rigidbody>();
            rigidbody.useGravity = false;
            Physics.gravity = new Vector3(0, 9.8f, 0);
        }

        public void UpdateMovement(InputSystem inputSystem)
        {
            float horizontalValue = inputSystem.GetHorizontalInput();
            
            if (inputSystem.IsDualityClicked())
            {
                gravityScale *= -1f;
                // Physics.gravity = new Vector2(10.0f, 10.0f);
            }
            
            animator.SetFloat("speed", Mathf.Abs(horizontalValue));
            animator.SetBool("isGrounded", controller.isGrounded);
            direction.x = horizontalValue * speed;
            // direction.y += gravity * Time.deltaTime;

            if (controller.isGrounded && inputSystem.IsJumpClicked())
            {
                // direction.y = jumpForce;
            }

            if (horizontalValue != 0)
            {
                Vector3 newDirection = new Vector3(horizontalValue, 0, 0);
                Quaternion newRotation = Quaternion.LookRotation(newDirection);
                model.rotation = newRotation;
            }
            
            // controller.Move(direction * Time.deltaTime);
        }

        private void FixedUpdate()
        {
            Vector3 gravity11 = Physics.gravity * gravityScale;
            // Vector3 gravity11 = globalGravity * gravityScale * Vector3.up;
            Debug.Log(gravity11);
            // rigidbody.AddForce(gravity11, ForceMode.Acceleration);
        }
    }
}