using System.Collections;
using System.Collections.Generic;
using Leadership.Core;
using UnityEngine;

namespace Leadership.Character
{
    public class FriendState : BaseState
    {
        protected StatusPlayerSM _statusSM;
        public FriendState(StatusPlayerSM stateMachine) : base("FriendState", stateMachine)
        {
            _statusSM = (StatusPlayerSM) stateMachine;
        }

        
    }
}
