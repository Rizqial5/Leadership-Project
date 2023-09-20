using System.Collections;
using System.Collections.Generic;
using Leadership.Core;
using Leadership.Attribute;
using UnityEngine;

namespace Leadership.Character
{
    public class GoldenState : BaseState
    {
        protected StatusPlayerSM _statusSM;
        public GoldenState(StatusPlayerSM stateMachine) : base("Golden", stateMachine)
        {
            _statusSM = (StatusPlayerSM) stateMachine;
        }

        public override void Enter()
        {
            _statusSM.GetCharacterMechanic().SetModifierAttribute(1.5f, LeadershipEnum.Morale);
            _statusSM.GetCharacterMechanic().SetModifierAttribute(1.5f, LeadershipEnum.Influence);
            _statusSM.GetCharacterMechanic().SetModifierAttribute(1.5f, LeadershipEnum.Trust);
            _statusSM.GetCharacterMechanic().SetModifierAttribute(1.5f, LeadershipEnum.Relation);

            
        }

        
    }
}
