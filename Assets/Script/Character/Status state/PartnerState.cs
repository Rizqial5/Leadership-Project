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

        
    }
}
