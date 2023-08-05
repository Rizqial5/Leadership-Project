using System.Collections;
using System.Collections.Generic;
using Leadership.Core;
using UnityEngine;

namespace Leadership.Character
{
    public class StatusPlayerSM : StateMachine
    {
        [HideInInspector] public FreeState freeState;
        [HideInInspector] public WorkState workState;

        private MovementSM _movementSM;
        private void Awake() 
        {
            freeState = new FreeState(this);
            workState = new WorkState(this);
            _movementSM = GetComponent<MovementSM>();
        }

        protected override BaseState GetInitialState()
        {
            return freeState;
        }
    }

}