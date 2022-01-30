using TMPro;
using UnityEngine;

namespace UI
{
    public class GameView : BaseView
    {
        [SerializeField]
        private TextMeshProUGUI coinsValue;
        
        public void UpdateCoins(int coins)
        {
            coinsValue.text = $"Coins: {coins}";
        }
    }
}