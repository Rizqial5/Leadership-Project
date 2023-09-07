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

        
    }
}
