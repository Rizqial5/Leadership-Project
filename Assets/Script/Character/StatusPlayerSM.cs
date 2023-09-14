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
            return characterMechanic.CheckLevelUp(1) && levelCheck == characterMechanic.GetLevelLead();
        }

        public string GetCurentStatusStateText()
        {
            return currentState.name;
        }

        public CharacterMechanic GetCharacterMechanic()
        {
            return characterMechanic;
        }

        public void PrintText(string value)
        {
            print(value);
        }

        public bool IsCharacterLevelUpTwo(bool value)
        {
            characterMechanic.IsLevelUpTwo = value;
           
            return characterMechanic.IsLevelUpTwo ;
        }

        public bool IsCharacterLevelUpThree(bool value)
        {
            characterMechanic.IsLevelUpThree = value;
           
            return characterMechanic.IsLevelUpThree ;
        }

        public bool IsCharacterLevelUpFour(bool value)
        {
            characterMechanic.IsLevelUpFour = value;
           
            return characterMechanic.IsLevelUpFour ;
        }

        public bool IsCharacterLevelUpFive(bool value)
        {
            characterMechanic.IsLevelUpFive = value;
           
            return characterMechanic.IsLevelUpFive;
        }
    }

}