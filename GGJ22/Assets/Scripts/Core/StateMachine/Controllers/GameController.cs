﻿using UI;
using UnityEngine;

namespace Core
{
    public class GameController : BaseController
    {
        private GameState gameState;

        [SerializeField]
        private GameView gameView;
       
        [SerializeField]
        private LoadingSystem loadingSystem;

        [SerializeField]
        private InputSystem inputSystem;
        
        [SerializeField]
        private PlayerMovementSystem playerMovementSystem;

        protected override void InjectReferences()
        {
            gameState = new GameState(
                gameView,
                loadingSystem,
                inputSystem,
                playerMovementSystem
            );
        }

        protected override void Start()
        {
            base.Start();
            ChangeState(gameState);
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