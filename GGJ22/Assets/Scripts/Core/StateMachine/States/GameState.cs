using UI;

namespace Core
{
    public class GameState : BaseState
    {
        private GameView gameView;
        private LoadingSystem loadingSystem;
        
        public GameState(
            GameView gameView,
            LoadingSystem loadingSystem
        )
        {
            this.gameView = gameView;
            this.loadingSystem = loadingSystem;
        }

        public override void InitState()
        {
            base.InitState();
            gameView.ShowView();
        }

        public override void UpdateState()
        {
            base.UpdateState();
        }

        public override void DestroyState()
        {
            gameView.HideView();
            base.DestroyState();
        }
    }
}