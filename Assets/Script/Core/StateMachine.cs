using UnityEngine;

namespace Leadership.Core
{
    public class StateMachine : MonoBehaviour
    {

        protected BaseState currentState;
        protected BaseState oldState;
  
        void Start()
        {
            currentState = GetInitialState();
            if(currentState != null)
            {
                currentState.Enter();
            }
        }

       
        void Update()
        {
            if(currentState != null)
            {
                currentState.UpdateLogic();
            }
        }

        void LateUpdate()
        {
            if(currentState != null)
            {
                currentState.UpdatePhysics();
            }
        }

        public void ChangeState(BaseState newState)
        {
            currentState.Exit();

            currentState = newState;
            currentState.Enter();
        }

        public BaseState GetCurrentState()
        {
            return currentState;
        }
 

        protected virtual BaseState GetInitialState()
        {
            return null;
        }

        public virtual void PlayButton()
        {
            currentState.Enter();
        }
        public virtual void PauseButton()
        {
            currentState.Exit();
        }
        
    }
}
