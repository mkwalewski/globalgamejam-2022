using UnityEngine;
using UnityEngine.Events;

namespace UI
{
    public class MenuView : BaseView
    {
        [SerializeField]
        private CustomButton startGameButton;

        [SerializeField]
        private CustomButton exitButton;
    
        public void InitView()
        {
            startGameButton.onClick.AddListener(startGameButton.RemoveAllListeners);
        }
        
        public void OnStartButtonClicked_AddListener(UnityAction listener)
        {
            startGameButton.onClick.AddListener(listener);
        }
        
        public void OnExitButtonClicked_AddListener(UnityAction listener)
        {
            exitButton.onClick.AddListener(listener);
        }
    }
}