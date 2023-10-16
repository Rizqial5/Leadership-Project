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

        }

        public override void UpdateLogic()
        {
            if(_statusSM.EligbleToNextLevel(4))
            {
                _statusSM.IsCharacterLevelUpFive(true);
               
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
