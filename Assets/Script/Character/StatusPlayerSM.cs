using System.Collections;
using System.Collections.Generic;
using Leadership.Core;
using UnityEngine;

namespace Leadership.Character
{
    public class StatusPlayerSM : StateMachine
    {
        [HideInInspector] public MemberState memberState;
        [HideInInspector] public FriendState friendState;
        [HideInInspector] public PartnerState partnerState;
        [HideInInspector] public ComradeState comradeState;
        [HideInInspector] public GoldenState goldenState;

        private GameSM _gameSM;
        private CharacterMechanic characterMechanic;
        private void Awake() 
        {
            memberState = new MemberState(this);
            friendState = new FriendState(this);
            partnerState = new PartnerState(this);
            comradeState = new ComradeState(this);
            goldenState = new GoldenState(this);

            _gameSM = FindObjectOfType<GameSM>();
            characterMechanic = GetComponent<CharacterMechanic>();
        }

        protected override BaseState GetInitialState()
        {
            return memberState;
        }

        public bool EligbleToNextLevel(int levelCheck)
        {
            return characterMechanic.CheckLevelUp() && levelCheck == characterMechanic.GetLevelLead();
        }

        public string GetCurentStatusStateText()
        {
            return currentState.name;
        }

        public void PrintText(string value)
        {
            print(value);
        }

        public bool IsCharacterLevelUp(bool value)
        {
            characterMechanic.IsLevelUp = value;
           
            return characterMechanic.IsLevelUp ;
        }
    }

}