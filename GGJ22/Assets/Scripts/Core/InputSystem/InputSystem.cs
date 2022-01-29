using UnityEngine;

namespace Core
{
    public class InputSystem : MonoBehaviour
    {
        private bool isEnabled;
        private float horizontalValue;
        private bool isJumpClicked;

        public float GetHorizontalInput()
        {
            return horizontalValue;
        }
        
        public bool IsJumpClicked()
        {
            return isJumpClicked;
        }
        
        public void EnableInput()
        {
            isEnabled = true;
        }

        public void DisableInput()
        {
            isEnabled = false;
            horizontalValue = 0f;
            isJumpClicked = false;
        }
        
        public void UpdateInput()
        {
            if (!isEnabled) return;
            horizontalValue = Input.GetAxis("Horizontal");
            isJumpClicked = Input.GetButtonDown("Jump");
        }
    }
}