using UI;
using UnityEngine;

namespace Core
{
    public class MenuController : BaseController
    {
        private MenuState menuState;
        
        [SerializeField]
        private MenuView menuView;
        
        [SerializeField]
        private LoadingView loadingView;
        
        [SerializeField]
        private LoadingSystem loadingSystem;
        
        protected override void InjectReferences()
        {
            menuState = new MenuState(
                menuView,
                loadingView,
                loadingSystem
            );
        }

        protected override void Start()
        {
            base.Start();
            ChangeState(menuState);
        }
        
        protected override void Update()
        {
            base.Update();
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
        }
    }
}