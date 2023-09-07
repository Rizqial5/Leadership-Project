using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Leadership.Core;
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


        public override void UpdateLogic()
        {
            if(_statusSM.EligbleToNextLevel(1))
            {
                _statusSM.ChangeState(_statusSM.friendState);

                _statusSM.IsCharacterLevelUpTwo(true);

                //test---
                // _statusSM.GetCharacterMechanic().LevelUP();
                //test----
                //bertujuan untuk memberikan tanda bahwa character itu sudah bisa level up
                

                //disini check lagi apakah case nya betul semua
                // if(_statusSM.CheckCaseLevelUp())

                //Jika betul semua nanti state pindah ke selanjutnya
                // _statusSM.ChangeState(_statusSM.friendState)
            }
        }

        
    }
}
