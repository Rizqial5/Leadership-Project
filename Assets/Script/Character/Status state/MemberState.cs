using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Leadership.Core;
using Leadership.Attribute;
using UnityEngine;

namespace Leadership.Character
{
    public class MemberState : BaseState
    {
        protected StatusPlayerSM _statusSM;
        public MemberState(StatusPlayerSM stateMachine) : base("Member", stateMachine)
        {
            _statusSM = (StatusPlayerSM) stateMachine;
        }


        public override void Enter()
        {
            
        }

        public override void UpdateLogic()
        {
            if(_statusSM.EligbleToNextLevel(1))
            {
                _statusSM.IsCharacterLevelUpTwo(true);


                if(_statusSM.GetCharacterLevelUpTwo() && _statusSM.LeadershipIsLevelUp(2))
                {
                    _statusSM.PrintText("Anggota level Up");
                    _statusSM.GetCharacterMechanic().LevelUP();
                    _statusSM.NextLevel();
                }
                // _statusSM.ChangeState(_statusSM.friendState)
            }else if(!_statusSM.EligbleToNextLevel(1))
            {
                _statusSM.IsCharacterLevelUpTwo(false);
            }

            // if(Input.GetKeyDown(KeyCode.G))
            // {
            //     _statusSM.NextLevel();
            // }
        }

        
    }
}
