using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Leadership.Core
{
    public class Play : BaseState
    {
        protected GameSM _gameSM;
        public Play(GameSM stateMachine) : base("Play", stateMachine)
        {
            _gameSM = (GameSM)stateMachine;
        }

        public override void Enter()
        {
            base.Enter();

          
        }

        public override void UpdateLogic()
        {
            base.UpdateLogic();


            _gameSM.turnSystem.TurnTime += Time.deltaTime * _gameSM.turnSystem.SpeedModifier;

            if(Input.GetKeyDown(KeyCode.Space))
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
                _gameSM.turnSystem.ToatlWeek += 1;

                _gameSM.turnSystem.OnChangeWeek.Invoke();
                stateMachine.ChangeState(_gameSM.planState);
               
            }
        }

        public override void Exit()
        {
            base.Exit();

            if(_gameSM.GetLeadershipMechanic().CanLevelUp(_gameSM.GetLeadershipMechanic().GetLevelLeadershipPlayer() + 1))
            {
                _gameSM.PrintNow("Bisa Level ON");
                
                //Notif untuk naik level nyala atau langsung pop up kalo sudah eligile level up
            }
        }
    }
}
