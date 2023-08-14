using System.Collections;
using System.Collections.Generic;
using Leadership.Attribute;
using UnityEngine;


namespace Leadership.Character
{
    public class CharacterMechanic : MonoBehaviour
    {
        [SerializeField] CharacterAttributesSO characterAttributes;

        public float GetStatsCharacter(LeadershipEnum leadershipEnum)
        {
            return characterAttributes.GetStatValue(leadershipEnum);
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
    }
}
