using UnityEngine;

namespace Core
{
    public abstract class BaseController : MonoBehaviour
    {
        private BaseState CurrentState;
        
        protected abstract void InjectReferences();
        
        protected virtual void Start()
        {
            InjectReferences();
            CurrentState?.InitState();
        }

        protected virtual void Update()
        {
            CurrentState?.UpdateState();
        }
        
        protected virtual void OnDestroy()
        {
            CurrentState?.DestroyState();
        }

        public void ChangeState(BaseState newState)
        {
            CurrentState?.DestroyState();
            CurrentState = newState;
            CurrentState.InitState();
        }
    }
}