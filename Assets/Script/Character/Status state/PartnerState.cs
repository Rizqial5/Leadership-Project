using System.Collections;
using System.Collections.Generic;
using Leadership.Core;
using Leadership.Attribute;
using UnityEngine;

namespace Leadership.Character
{
    public class PartnerState : BaseState
    {
        protected StatusPlayerSM _statusSM;
        public PartnerState(StatusPlayerSM stateMachine) : base("Partner", stateMachine)
        {
            _statusSM = (StatusPlayerSM) stateMachine;
        }

        public override void Enter()
        {
            _statusSM.GetCharacterMechanic().SetModifierAttribute(1.2f, LeadershipEnum.Trust);

            //relationship Event Unlock
            //notif relationship event
        }

        public override void UpdateLogic()
        {
            if(_statusSM.EligbleToNextLevel(3))
            {
                _statusSM.IsCharacterLevelUpFour(true);
                //bertujuan untuk memberikan tanda bahwa character itu sudah bisa level up
                //test---
               
                if(_statusSM.GetCharacterLevelUpTwo() && _statusSM.LeadershipIsLevelUp(4))
                {
                    _statusSM.PrintText("Anggota level Up");
                    _statusSM.GetCharacterMechanic().LevelUP();
                    _statusSM.NextLevel();
                }
            }else if(!_statusSM.EligbleToNextLevel(3))
            {
                _statusSM.IsCharacterLevelUpFour(false);
            }

            // Testing Only
            if(Input.GetKeyDown(KeyCode.G))
            {
                _statusSM.NextLevel();
            }
        }
    }
}
