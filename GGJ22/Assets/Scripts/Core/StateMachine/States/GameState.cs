using UI;

namespace Core
{
    public class GameState : BaseState
    {
        private GameView gameView;
        private LoadingSystem loadingSystem;
        private InputSystem inputSystem;
        private CameraSystem cameraSystem;
        private PlayerMovementSystem playerMovementSystem;
        private PlayerDataSystem playerDataSystem;
        
        public GameState(
            GameView gameView,
            LoadingSystem loadingSystem,
            InputSystem inputSystem,
            CameraSystem cameraSystem,
            PlayerMovementSystem playerMovementSystem,
            PlayerDataSystem playerDataSystem
        )
        {
            this.gameView = gameView;
            this.loadingSystem = loadingSystem;
            this.inputSystem = inputSystem;
            this.cameraSystem = cameraSystem;
            this.playerMovementSystem = playerMovementSystem;
            this.playerDataSystem = playerDataSystem;
        }

        public override void InitState()
        {
            base.InitState();
            int coins = CoinsValues.INIT_VALUE;
            gameView.ShowView();
            gameView.UpdateCoins(coins);
            inputSystem.EnableInput();
            cameraSystem.StartCamera();
            playerDataSystem.SetCoins(coins);
        }

        public override void UpdateState()
        {
            base.UpdateState();
            gameView.UpdateCoins(playerDataSystem.GetCoins());
            inputSystem.UpdateInput();
            cameraSystem.UpdateCamera();
            playerMovementSystem.UpdateMovement(inputSystem);
        }

        public override void DestroyState()
        {
            gameView.HideView();
            inputSystem.DisableInput();
            base.DestroyState();
        }
    }
}