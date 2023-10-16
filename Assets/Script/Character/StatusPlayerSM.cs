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
        private LeadershipMechanic leadershipMechanic;
        private void Awake() 
        {
            memberState = new MemberState(this);
            friendState = new FriendState(this);
            partnerState = new PartnerState(this);
            comradeState = new ComradeState(this);
            goldenState = new GoldenState(this);

            _gameSM = FindObjectOfType<GameSM>();
            characterMechanic = GetComponent<CharacterMechanic>();
            leadershipMechanic = FindObjectOfType<LeadershipMechanic>();
        }

        protected override BaseState GetInitialState()
        {
            return memberState;
        }

        public bool EligbleToNextLevel(int levelCheck)
        {
            return characterMechanic.CheckLevelUp(1) && levelCheck == characterMechanic.GetLevelLead();
        }

        public void NextLevel()
        {
            if(currentState == memberState)
            {
                ChangeState(friendState);

            }else if(currentState == friendState)
            {
                ChangeState(partnerState);

            }else if(currentState == partnerState)
            {
                ChangeState(comradeState);

            }else if(currentState == comradeState)
            {
                ChangeState(goldenState);

            }
        }

        public string GetCurentStatusStateText()
        {
            return currentState.name;
        }

        public CharacterMechanic GetCharacterMechanic()
        {
            return characterMechanic;
        }
        public LeadershipMechanic GetLeadershipMechanic()
        {
            return leadershipMechanic;
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

        public bool GetCharacterLevelUpTwo()
        {
            return characterMechanic.IsLevelUpTwo;
        }

        public bool IsCharacterLevelUpThree(bool value)
        {
            characterMechanic.IsLevelUpThree = value;
           
            return characterMechanic.IsLevelUpThree ;
        }
        public bool GetCharacterLevelUpThree()
        {
            return characterMechanic.IsLevelUpThree;
        }

        public bool IsCharacterLevelUpFour(bool value)
        {
            characterMechanic.IsLevelUpFour = value;
           
            return characterMechanic.IsLevelUpFour ;
        }
        public bool GetCharacterLevelUpFour()
        {
            return characterMechanic.IsLevelUpFour;
        }

        public bool IsCharacterLevelUpFive(bool value)
        {
            characterMechanic.IsLevelUpFive = value;
           
            return characterMechanic.IsLevelUpFive;
        }
        public bool GetCharacterLevelUpFive()
        {
            return characterMechanic.IsLevelUpFive;
        }

        public bool LeadershipIsLevelUp(int levelCap)
        {
            if(leadershipMechanic.GetLevelLeadershipPlayer() >= levelCap)
            {
                return true;
            }

            return false;
        }
    }

}