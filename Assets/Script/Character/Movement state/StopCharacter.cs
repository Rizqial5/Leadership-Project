using System.Collections;
using System.Collections.Generic;
using Leadership.Core;
using UnityEngine;

namespace Leadership.Character
{
    public class StopCharacter : BaseState
    {
        protected MovementSM _moveSM;
        public StopCharacter(MovementSM stateMachine) : base("StopChar", stateMachine)
        {
            _moveSM = (MovementSM)stateMachine;
        }

        public override void Enter()
        {
            base.Enter();
            

            _moveSM.agent.updateRotation = false;
            _moveSM.agent.updateUpAxis = false;

            
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
