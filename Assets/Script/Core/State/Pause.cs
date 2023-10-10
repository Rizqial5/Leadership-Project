using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Leadership.Core
{
    public class Pause : BaseState
    {
        protected GameSM _gameSM;
        public Pause(GameSM stateMachine) : base("Mode Pause", stateMachine)
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
