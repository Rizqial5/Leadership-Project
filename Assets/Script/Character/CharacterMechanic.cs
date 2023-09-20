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

        private float modifierRelation = 1;
        private float modifierMorale = 1;
        private float modifierInfluence = 1;
        private float modifierTrust = 1;

        private bool isLevelUp = false;
        [SerializeField] private bool isLevelUpTwo = false;
        private bool isLevelUpThree = false;
        private bool isLevelUpFour = false;
        private bool isLevelUpFive= false;
        

        void Update()
        {
            // if(Input.GetKeyDown(KeyCode.Y))
            // {
            //     LevelUP();
            // }
            // if(Input.GetKeyDown(KeyCode.U))
            // {
            //     AddStatsCharacter(LeadershipEnum.Relation,5);
            // }

        ////Testing
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
            levelLeadNow ++;
        }

        public bool CheckLevelUp(int add)
        {
            return GetStatsCharacter(LeadershipEnum.Relation) >= leadershipProgression.GetRequireStat(LeadershipEnum.Relation, levelLeadNow + add ) &&
                        GetStatsCharacter(LeadershipEnum.Trust) >= leadershipProgression.GetRequireStat(LeadershipEnum.Trust, levelLeadNow + add ) &&
                        GetStatsCharacter(LeadershipEnum.Influence) >= leadershipProgression.GetRequireStat(LeadershipEnum.Influence, levelLeadNow + add ) &&
                        GetStatsCharacter(LeadershipEnum.Morale) >= leadershipProgression.GetRequireStat(LeadershipEnum.Morale, levelLeadNow + add );
        }

        public void AddStatsCharacter(LeadershipEnum leadershipEnum, float value)
        {
            if(CheckLevelUp(1) && value > 0) return;
            if(leadershipEnum == LeadershipEnum.Relation)
            {
                characterAttributes.AddStatValue(leadershipEnum,value * modifierRelation);

            }else if(leadershipEnum == LeadershipEnum.Trust)
            {
                characterAttributes.AddStatValue(leadershipEnum,value * modifierTrust);

            }else if(leadershipEnum == LeadershipEnum.Influence)
            {
                characterAttributes.AddStatValue(leadershipEnum,value * modifierInfluence);

            }
            else if(leadershipEnum == LeadershipEnum.Morale)
            {
                characterAttributes.AddStatValue(leadershipEnum,value * modifierMorale);

            }
            else
            {
                 characterAttributes.AddStatValue(leadershipEnum,value);
            }

            
        }

        public float SetModifierAttribute(float value, LeadershipEnum leadershipEnum)
        {
            if(leadershipEnum == LeadershipEnum.Relation)
            {
                return modifierRelation = value;

            }else if(leadershipEnum == LeadershipEnum.Influence)
            {
                return modifierInfluence = value;
            }else if(leadershipEnum == LeadershipEnum.Trust)
            {
                return modifierTrust = value;
            }else if(leadershipEnum == LeadershipEnum.Morale)
            {
                return modifierInfluence = value;
            }else
            {
                return 0;
            }
            
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
