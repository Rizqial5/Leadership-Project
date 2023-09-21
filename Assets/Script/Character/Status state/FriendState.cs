using System.Collections;
using System.Collections.Generic;
using Leadership.Attribute;
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

        public override void Enter()
        {
            _statusSM.GetCharacterMechanic().SetModifierAttribute(1.2f, LeadershipEnum.Relation);

            //relationship Event Unlock
            //notif relationship event
        }

        public override void UpdateLogic()
        {
            if(_statusSM.EligbleToNextLevel(2))
            {
                _statusSM.IsCharacterLevelUpThree(true);
               
                //bertujuan untuk memberikan tanda bahwa character itu sudah bisa level up
                //test---
               
                //test----

                if(_statusSM.GetCharacterLevelUpTwo() && _statusSM.LeadershipIsLevelUp(3))
                {
                    _statusSM.PrintText("Anggota level Up");
                    _statusSM.GetCharacterMechanic().LevelUP();
                    _statusSM.NextLevel();
                }
            }else if(!_statusSM.EligbleToNextLevel(2))
            {
                _statusSM.IsCharacterLevelUpThree(false);
            }


            // Testing Only
            if(Input.GetKeyDown(KeyCode.G))
            {
                _statusSM.NextLevel();
            }
        }
    }
}
