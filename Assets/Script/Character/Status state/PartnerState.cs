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
                _statusSM.GetCharacterMechanic().LevelUP();
                //test----

                //disini check lagi apakah case nya betul semua
                // if(_statusSM.CheckCaseLevelUp())

                //Jika betul semua nanti state pindah ke selanjutnya
                // _statusSM.ChangeState(_statusSM.friendState)
            }
        }
    }
}
