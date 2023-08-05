using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace Leadership.Attribute
{
    [CreateAssetMenu(fileName = "LeadershipAttributesSO", menuName = "Leadership Project/LeadershipAttributesSO", order = 0)]
    public class LeadershipAttributesSO : ScriptableObject 
    {
        [SerializeField] LeadershipAttributesTotal[] leadershipAttributesTotal;
        
        [SerializeField] DivisionEnum joinedMeetingInDivision;
        [SerializeField] public float dummyNumber;

        Dictionary<LeadershipEnum,float> leadershipLookupTable;


        

        public void SetLeadershipAttributes(LeadershipEnum leadershipEnum, float value)
        {
            BuildLookupTable();

            leadershipLookupTable[leadershipEnum] = value; 
        }

        public float GetLeadershipAttributes(LeadershipEnum leadershipEnum)
        {
            BuildLookupTable();

            return leadershipLookupTable[leadershipEnum];
        }
        public void BuildLookupTable()
        {
            if(leadershipLookupTable != null) return;

            leadershipLookupTable = new Dictionary<LeadershipEnum,float>();

            foreach (LeadershipAttributesTotal leadershipAttributes in leadershipAttributesTotal)
            {
                leadershipLookupTable[leadershipAttributes.category] = leadershipAttributes.total;
            }
        }




        
        public DivisionEnum SetJoinedMeetingDivision(DivisionEnum divisionEnum)
        {
            return joinedMeetingInDivision = divisionEnum;
        }
    }

    [System.Serializable]

    public class LeadershipAttributesTotal
    {
        [SerializeField] public LeadershipEnum category;
        [SerializeField] public float total;
    }
}
