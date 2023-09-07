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

        // public void LevelUP()
        // {
        //     if(levelLeadNow == 5) return;
        //     if(CheckLevelUp())
        //     {
        //         print("Bisa");

        //         isLevelUp = true;
        //     }

        //     if(isLevelUp == true)
        //     {
        //         levelLeadNow += 1;
        //         isLevelUp = false;
        //     }
        // }

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
    }
}
