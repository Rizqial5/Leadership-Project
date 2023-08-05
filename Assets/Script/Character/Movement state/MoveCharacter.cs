using System.Collections;
using System.Collections.Generic;
using Leadership.Core;
using UnityEngine;
using UnityEngine.AI;

namespace Leadership.Character
{
    public class MoveCharacter : BaseState
    {
        protected MovementSM _moveSM;
        public MoveCharacter(MovementSM stateMachine) : base("MoveChar", stateMachine)
        {
            _moveSM = (MovementSM) stateMachine;
        }

        public override void Enter()
        {
            base.Enter();
    
        }

        public override void UpdateLogic()
        {
            base.UpdateLogic();

            if(_moveSM.gameSM.GetCurrentState() == _moveSM.gameSM.planState)
            {
                stateMachine.ChangeState(_moveSM.planCharState);
            }

            if(_moveSM.gameSM.GetCurrentState() == _moveSM.gameSM.pauseState)
            {
                _moveSM.ChangeState(_moveSM.pauseCharState);
            }



            if(_moveSM.target == null) return;

            _moveSM.animator.SetBool("IsTarget", true);
            _moveSM.agent.isStopped = false;
           
            _moveSM.agent.SetDestination(_moveSM.target.position);

            

        }

        public override void UpdatePhysics()
        {
            base.UpdatePhysics();
            _moveSM.animator.speed = 1;
            
            if(_moveSM.target == null) return;

            _moveSM.dir = _moveSM.target.position - _moveSM.transform.position;
            _moveSM.dir.Normalize();
            
            

            _moveSM.animator.SetFloat("Horizontal", ( _moveSM.dir.x));
            _moveSM.animator.SetFloat("Vertical", ( _moveSM.dir.y));
        }







        
    }
}
