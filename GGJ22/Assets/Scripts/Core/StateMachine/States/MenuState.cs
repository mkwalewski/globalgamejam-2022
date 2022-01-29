using UI;
using UnityEngine;

namespace Core
{
    public class MenuState : BaseState
    {
        private MenuView menuView;
        private LoadingView loadingView;
        private LoadingSystem loadingSystem;
        
        public MenuState(
            MenuView menuView,
            LoadingView loadingView,
            LoadingSystem loadingSystem
        )
        {
            this.menuView = menuView;
            this.loadingView = loadingView;
            this.loadingSystem = loadingSystem;
        }
        
        public override void InitState()
        {
            base.InitState();
            menuView.InitView();
            menuView.ShowView();
            menuView.OnStartButtonClicked_AddListener(StartGame);
            menuView.OnExitButtonClicked_AddListener(ExitGame);
        }

        public override void UpdateState()
        {
            base.UpdateState();
        }

        public override void DestroyState()
        {
            menuView.HideView();
            base.DestroyState();
        }
        
        private void StartGame()
        {
            loadingView.ShowView();
            loadingSystem.StartLoadingScene(1);
        }

        private void ExitGame()
        {
            Application.Quit();
        }
    }
}