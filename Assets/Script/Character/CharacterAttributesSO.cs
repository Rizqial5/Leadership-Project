using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leadership.Attribute;



namespace Leadership.Character
{
    [CreateAssetMenu(menuName = "Leadership Project/CharacterAttributesSO")]
    public class CharacterAttributesSO : ScriptableObject
    {
        [SerializeField] string nameCharacter;
        [SerializeField] DivisionEnum divisionEnum;
        [SerializeField] CharacterLeaderStats[] characterLeaderStatsTotal;
        [SerializeField] int leadershpLevel;
        

        Dictionary<LeadershipEnum, float> characterValueStatsTable;

        private void BuildLookupTable()
        {
            if(characterValueStatsTable != null) return;

            characterValueStatsTable = new Dictionary<LeadershipEnum,float>();

            foreach (CharacterLeaderStats characterStats in characterLeaderStatsTotal)
            {
                characterValueStatsTable[characterStats.category] = characterStats.value;
            }
        }

        public float GetStatValue(LeadershipEnum category)
        {
            BuildLookupTable();

            return characterValueStatsTable[category];

        }

        public string GetNameCharacter()
        {
            return nameCharacter;
        }

        public DivisionEnum GetDivisionCharacter()
        {
            return divisionEnum;
        }

        public int GetLeadershipLevel()
        {
            return leadershpLevel;
        }

        public void AddStatValue(LeadershipEnum category, float value)
        {
            BuildLookupTable();

            characterValueStatsTable[category] += value;
        }

    }

    [System.Serializable]
    public class CharacterLeaderStats
    {
        public LeadershipEnum category;
        public float value;

    }
}