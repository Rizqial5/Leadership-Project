using Leadership.Core;


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

            if(_moveSM.gameSM.GetCurrentState() == _moveSM.gameSM.planState || _moveSM.gameSM.GetCurrentState() == _moveSM.gameSM.pauseState)
            {
                stateMachine.ChangeState(_moveSM.stopCharState);
            }

            



            if(_moveSM.targetLoc == null) return;

            _moveSM.animator.SetBool("IsTarget", true);
            _moveSM.agent.isStopped = false;
            _moveSM.agent.speed *= _moveSM.GetSpeedModifier() / 2;
           
            _moveSM.agent.SetDestination(_moveSM.targetLoc.position);

            

        }

        public override void UpdatePhysics()
        {
            base.UpdatePhysics();
            _moveSM.animator.speed = 1;
            
            if(_moveSM.targetLoc == null) return;

            _moveSM.dir = _moveSM.targetLoc.position - _moveSM.transform.position;
            _moveSM.dir.Normalize();
            
            

            _moveSM.animator.SetFloat("Horizontal", ( _moveSM.dir.x));
            _moveSM.animator.SetFloat("Vertical", ( _moveSM.dir.y));
        }







        
    }
}
