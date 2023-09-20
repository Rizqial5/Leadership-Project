using System.Collections;
using System.Collections.Generic;
using Leadership.Core;
using Leadership.Attribute;
using UnityEngine;

namespace Leadership.Character
{
    public class ComradeState : BaseState
    {
        protected StatusPlayerSM _statusSM;
        public ComradeState(StatusPlayerSM stateMachine) : base("Comrade", stateMachine)
        {
            _statusSM = (StatusPlayerSM) stateMachine;
        }

        public override void Enter()
        {
            _statusSM.GetCharacterMechanic().SetModifierAttribute(1.2f,LeadershipEnum.Influence);

            //relationship Event Unlock
            //notif relationship event
        }

        public override void UpdateLogic()
        {
            if(_statusSM.EligbleToNextLevel(5))
            {
               
                //bertujuan untuk memberikan tanda bahwa character itu sudah bisa level up
                //test---
               if(_statusSM.GetCharacterLevelUpTwo() && _statusSM.LeadershipIsLevelUp(5))
                {
                    _statusSM.PrintText("Anggota level Up");
                    _statusSM.GetCharacterMechanic().LevelUP();
                    _statusSM.NextLevel();
                }
            }else if(!_statusSM.EligbleToNextLevel(5))
            {
                _statusSM.IsCharacterLevelUpFive(false);
            }
        }
    }
}
