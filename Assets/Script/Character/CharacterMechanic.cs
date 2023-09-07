using System.Collections;
using System.Collections.Generic;
using Leadership.Attribute;
using UnityEngine;


namespace Leadership.Character
{
    public class CharacterMechanic : MonoBehaviour
    {
        [SerializeField] CharacterAttributesSO characterAttributes;
        [SerializeField] LeadershipProgression leadershipProgression;

        [SerializeField] int levelLeadNow = 1;

        private bool isLevelUp = false;
        private bool isLevelUpTwo = false;
        private bool isLevelUpThree = false;
        private bool isLevelUpFour = false;
        private bool isLevelUpFive= false;

        void Update()
        {
            // LevelUP();
        }
        public float GetStatsCharacter(LeadershipEnum leadershipEnum)
        {
            return characterAttributes.GetStatValue(leadershipEnum);
        }

        public Dictionary<LeadershipEnum,float> GetAllStatChar()
        {
            return characterAttributes.GetAllStat();
        }

        public void LevelUP()
        {
            if(levelLeadNow == 5) return;
            if(CheckLevelUp())
            {
                print("Bisa");

                isLevelUp = true;
            }

            if(isLevelUp == true)
            {
                levelLeadNow += 1;
                isLevelUp = false;
            }
        }

        public bool CheckLevelUp()
        {
            return GetStatsCharacter(LeadershipEnum.Relation) >= leadershipProgression.GetRequireStat(LeadershipEnum.Relation, levelLeadNow + 1) &&
                        GetStatsCharacter(LeadershipEnum.Trust) >= leadershipProgression.GetRequireStat(LeadershipEnum.Trust, levelLeadNow + 1) &&
                        GetStatsCharacter(LeadershipEnum.Influence) >= leadershipProgression.GetRequireStat(LeadershipEnum.Influence, levelLeadNow + 1) &&
                        GetStatsCharacter(LeadershipEnum.Morale) >= leadershipProgression.GetRequireStat(LeadershipEnum.Morale, levelLeadNow + 1);
        }

        public void AddStatsCharacter(LeadershipEnum leadershipEnum, float value)
        {
            characterAttributes.AddStatValue(leadershipEnum,value);
        }

        // testing------------------
        public void AddAllStatsChar(float value)
        {
            characterAttributes.AddStatValue(LeadershipEnum.Relation,value);
            characterAttributes.AddStatValue(LeadershipEnum.Trust,value);
            characterAttributes.AddStatValue(LeadershipEnum.Influence,value);
            characterAttributes.AddStatValue(LeadershipEnum.Morale,value);
        }

        public string GetNameCharacter()
        {
            return characterAttributes.GetNameCharacter();
        }

        public DivisionEnum GetDivisionCharacter()
        {
            return characterAttributes.GetDivisionCharacter();
        }

        public int GetLevelLead()
        {
            return levelLeadNow;
        }

        public bool IsLevelUpTwo
        {
            get{return isLevelUpTwo;} set{isLevelUpTwo = value;}
        }

        public bool IsLevelUpThree
        {
            get{return isLevelUpThree;} set{isLevelUpThree= value;}
        }

        public bool IsLevelUpFour
        {
            get{return isLevelUpFour;} set{isLevelUpFour= value;}
        }

        public bool IsLevelUpFive
        {
            get{return isLevelUpFive;} set{isLevelUpFive= value;}
        }
    }
}
