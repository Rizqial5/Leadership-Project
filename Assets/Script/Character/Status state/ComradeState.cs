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
