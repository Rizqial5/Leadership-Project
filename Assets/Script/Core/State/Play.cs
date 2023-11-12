using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Leadership.Core
{
    public class Play : BaseState
    {
        protected GameSM _gameSM;
        public Play(GameSM stateMachine) : base("Mode Play", stateMachine)
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


            _gameSM.turnSystem.TurnTime += Time.deltaTime * _gameSM.turnSystem.SpeedModifier;

            if(Input.GetKeyDown(KeyCode.Space))
            {
                _gameSM.ChangeState(_gameSM.pauseState);
            }

            if(_gameSM.GetActionDatabase().GetActionIsPlay() == true)
            {
                _gameSM.ChangeState(_gameSM.pauseState);
            }

            if (_gameSM.turnSystem.TurnTime  >= 3f)
            {
                _gameSM.turnSystem.TurnTime  = 0f;
                _gameSM.turnSystem.ChangeTimeADay(1);
                _gameSM.turnSystem.OnChangeTime.Invoke();
                
               
            }
            if (_gameSM.turnSystem.GetTimeDay() == 4)
            {
                _gameSM.turnSystem.SetTimeDay(1);
                _gameSM.turnSystem.CalenderTime += 1;
                
                _gameSM.turnSystem.OnChangeDays.Invoke();
                
                
            }
            if (_gameSM.ChangeWeek())
            {
                _gameSM.turnSystem.CalenderTime = 1;
                

                _gameSM.turnSystem.OnChangeWeek.Invoke();
                stateMachine.ChangeState(_gameSM.planState);
               
            }
        }

        public override void Exit()
        {
            base.Exit();
            int levelPlayerNow = _gameSM.GetLeadershipMechanic().GetLevelLeadershipPlayer() + 1;

            _gameSM.GetLeadershipMechanic().CanLevelUp(levelPlayerNow);
            
        }
    }
}
