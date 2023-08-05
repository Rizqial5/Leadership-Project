using System.Collections;
using System.Collections.Generic;
using Leadership.Core;
using UnityEngine;

namespace Leadership.Character
{
    public class FreeState : BaseState
    {
        public FreeState(StatusPlayerSM stateMachine) : base("FreeState", stateMachine)
        {
        }

        
    }
}
