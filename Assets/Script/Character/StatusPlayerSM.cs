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

        private GameSM _gameSM;
        private void Awake() 
        {
            freeState = new FreeState(this);
            workState = new WorkState(this);

            _gameSM = FindObjectOfType<GameSM>();
        }

        protected override BaseState GetInitialState()
        {
            return freeState;
        }
    }

}