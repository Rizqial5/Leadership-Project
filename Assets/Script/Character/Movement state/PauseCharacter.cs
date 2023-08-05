using System.Collections;
using System.Collections.Generic;
using Leadership.Core;
using UnityEngine;

namespace Leadership.Character
{
    public class PauseCharacter : BaseState
    {
        protected MovementSM _moveSM;
        public PauseCharacter(MovementSM stateMachine) : base("PauseChar", stateMachine)
        {
            _moveSM = (MovementSM)stateMachine;
        }

        public override void Enter()
        {
            base.Enter();

            
            
            
        }

        public override void UpdateLogic()
        {
            base.UpdateLogic();

            _moveSM.agent.isStopped = true;

            if(_moveSM.gameSM.GetCurrentState() == _moveSM.gameSM.playState)
            {
                _moveSM.ChangeState(_moveSM.moveCharState);
            }

        }

        public override void UpdatePhysics()
        {
            base.UpdatePhysics();
            
            _moveSM.animator.speed = 0;
        }
    }
}
