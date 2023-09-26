using Leadership.Action;
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

        private LeadershipMechanic leadershipMechanic;
        private ActionDatabase actionDatabase;
        

        


        private void Awake() 
        {
            planState = new Plan(this);
            playState = new Play(this);
            pauseState = new Pause(this);

            leadershipMechanic = FindObjectOfType<LeadershipMechanic>();
            actionDatabase = FindObjectOfType<ActionDatabase>();
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

        public void PrintNow(string value)
        {
            print(value);
        }

        

        // private void OnGUI() 
        // {
        //     string content = currentState != null ? currentState.name : "(no current state)";
        //     GUILayout.Label($"<color='black'><size=40>{content}</size></color>");    
        // }


        public LeadershipMechanic GetLeadershipMechanic()
        {
            return leadershipMechanic;
        }

        public ActionDatabase GetActionDatabase()
        {
            return actionDatabase;
        }
    }
}
