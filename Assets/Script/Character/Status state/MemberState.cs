using System.Collections;
using System.Collections.Generic;
using Leadership.Core;
using UnityEngine;

namespace Leadership.Character
{
    public class MemberState : BaseState
    {
        protected StatusPlayerSM _statusSM;
        public MemberState(StatusPlayerSM stateMachine) : base("MemberState", stateMachine)
        {
            _statusSM = (StatusPlayerSM) stateMachine;
        }

        
    }
}
