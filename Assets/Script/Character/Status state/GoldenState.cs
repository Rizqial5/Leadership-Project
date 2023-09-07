using System.Collections;
using System.Collections.Generic;
using Leadership.Core;
using UnityEngine;

namespace Leadership.Character
{
    public class GoldenState : BaseState
    {
        protected StatusPlayerSM _statusSM;
        public GoldenState(StatusPlayerSM stateMachine) : base("GoldenState", stateMachine)
        {
            _statusSM = (StatusPlayerSM) stateMachine;
        }

        
    }
}
