using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Leadership.Core
{
    public class Plan : BaseState
    {
        protected GameSM _gameSM;
        public Plan(GameSM stateMachine) : base("Plan", stateMachine)
        {
            _gameSM = (GameSM)stateMachine;
        }

        public override void Enter()
        {
            base.Enter();

            if(_gameSM.GetLeadershipMechanic().CanLevelUp(_gameSM.GetLeadershipMechanic().GetLevelLeadershipPlayer() + 1))
            {
                // _gameSM.PrintNow("Bisa Level ON");
                //Notif untuk naik level nyala atau langsung pop up kalo sudah eligile level up
            }

            
            
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
