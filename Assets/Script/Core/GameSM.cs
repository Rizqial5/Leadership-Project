using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Leadership.Core
{
    public class GameSM : StateMachine
    {
        [HideInInspector]
        public Plan planState;
        public Play playState;
        public Pause pauseState;

        [SerializeField] public TurnSystem turnSystem;
        

        


        private void Awake() 
        {
            planState = new Plan(this);
            playState = new Play(this);
            pauseState = new Pause(this);
        }

        public override void PlayButton()
        {
            currentState = playState;
            base.PlayButton();
            
        }

        public override void PauseButton()
        {
            if (IsPlanState()) return;
            base.PauseButton();
            
            currentState = pauseState;
        }

        public bool IsPlanState()
        {
            return currentState == planState;
        }

        public bool ChangeWeek()
        {
            return turnSystem.CalenderTime >= 8;
        }

        protected override BaseState GetInitialState()
        {
            return planState;
        }

        

        // private void OnGUI() 
        // {
        //     string content = currentState != null ? currentState.name : "(no current state)";
        //     GUILayout.Label($"<color='black'><size=40>{content}</size></color>");    
        // }
    }
}
