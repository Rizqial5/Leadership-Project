using System.Collections;
using System.Collections.Generic;
using Leadership.Core;
using UnityEngine;

namespace Leadership.Character
{
    public class FriendState : BaseState
    {
        protected StatusPlayerSM _statusSM;
        public FriendState(StatusPlayerSM stateMachine) : base("Friend", stateMachine)
        {
            _statusSM = (StatusPlayerSM) stateMachine;
        }

        public override void UpdateLogic()
        {
            if(_statusSM.EligbleToNextLevel(2))
            {
                _statusSM.ChangeState(_statusSM.partnerState);
                //bertujuan untuk memberikan tanda bahwa character itu sudah bisa level up
                //test---
               
                //test----

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
