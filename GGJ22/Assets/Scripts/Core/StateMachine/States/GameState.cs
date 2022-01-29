using UI;

namespace Core
{
    public class GameState : BaseState
    {
        private GameView gameView;
        private LoadingSystem loadingSystem;
        private InputSystem inputSystem;
        private PlayerMovementSystem playerMovementSystem;
        
        public GameState(
            GameView gameView,
            LoadingSystem loadingSystem,
            InputSystem inputSystem,
            PlayerMovementSystem playerMovementSystem
        )
        {
            this.gameView = gameView;
            this.loadingSystem = loadingSystem;
            this.inputSystem = inputSystem;
            this.playerMovementSystem = playerMovementSystem;
        }

        public override void InitState()
        {
            base.InitState();
            gameView.ShowView();
            inputSystem.EnableInput();
        }

        public override void UpdateState()
        {
            base.UpdateState();
            inputSystem.UpdateInput();
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