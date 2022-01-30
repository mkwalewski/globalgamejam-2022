using UnityEngine;

namespace Core
{
    public class InputSystem : MonoBehaviour
    {
        private bool isEnabled;
        private float horizontalValue;
        private bool isJumpClicked;
        private bool isDualityClicked;

        public float GetHorizontalInput()
        {
            return horizontalValue;
        }
        
        public bool IsJumpClicked()
        {
            return isJumpClicked;
        }
        
        public bool IsDualityClicked()
        {
            return isDualityClicked;
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
            isDualityClicked = false;
        }
        
        public void UpdateInput()
        {
            if (!isEnabled) return;
            horizontalValue = Input.GetAxis("Horizontal");
            isJumpClicked = Input.GetButtonDown("Jump");
            isDualityClicked = Input.GetKeyDown(KeyCode.Tab);
        }
    }
}