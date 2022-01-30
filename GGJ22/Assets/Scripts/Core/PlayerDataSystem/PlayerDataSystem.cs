using UnityEngine;

namespace Core
{
    public class CoinsValues
    {
        public const int INIT_VALUE = 0;
    }
    
    public class PlayerDataSystem : MonoBehaviour
    {
        private int coins;
        
        public int GetCoins()
        {
            return coins;
        }
        
        public void SetCoins(int coins)
        {
            this.coins = coins;
        }
        
        public void AddCoin()
        {
            coins++;
        }
    }
}