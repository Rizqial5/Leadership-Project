using System.Collections;
using System.Collections.Generic;
using Leadership.Core;
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

        public override void UpdateLogic()
        {
            if(_statusSM.EligbleToNextLevel(3))
            {
                _statusSM.ChangeState(_statusSM.comradeState);
                //bertujuan untuk memberikan tanda bahwa character itu sudah bisa level up
                //test---
               
                if(_statusSM.GetCharacterLevelUpTwo() && _statusSM.LeadershipIsLevelUp(2))
                {
                    _statusSM.PrintText("Anggota level Up");
                    _statusSM.GetCharacterMechanic().LevelUP();
                    _statusSM.NextLevel();
                }
            }
        }
    }
}
