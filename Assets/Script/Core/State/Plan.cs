using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Leadership.Core
{
    public class Plan : BaseState
    {
        protected GameSM _gameSM;
        public Plan(GameSM stateMachine) : base("Mode Plan", stateMachine)
        {
            _gameSM = (GameSM)stateMachine;
        }

        public override void Enter()
        {
            base.Enter();


            _gameSM.ChangeModeText();


        }

        public override void UpdateLogic()
        {
            base.UpdateLogic();

            

            if(Input.GetKeyDown(KeyCode.Space))
            {
                _gameSM.ChangeState(_gameSM.playState);
            }

            
        }
    }
}
