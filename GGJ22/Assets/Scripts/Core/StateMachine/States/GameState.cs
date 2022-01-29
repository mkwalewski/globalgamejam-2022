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
        
        public GameState(
            GameView gameView,
            LoadingSystem loadingSystem,
            InputSystem inputSystem,
            CameraSystem cameraSystem,
            PlayerMovementSystem playerMovementSystem
        )
        {
            this.gameView = gameView;
            this.loadingSystem = loadingSystem;
            this.inputSystem = inputSystem;
            this.cameraSystem = cameraSystem;
            this.playerMovementSystem = playerMovementSystem;
        }

        public override void InitState()
        {
            base.InitState();
            gameView.ShowView();
            inputSystem.EnableInput();
            cameraSystem.StartCamera();
        }

        public override void UpdateState()
        {
            base.UpdateState();
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