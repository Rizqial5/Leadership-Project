using System.Collections;
using System.Collections.Generic;
using Leadership.Core;
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

        public override void UpdateLogic()
        {
            if(_statusSM.EligbleToNextLevel(4))
            {
                _statusSM.ChangeState(_statusSM.goldenState);
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
