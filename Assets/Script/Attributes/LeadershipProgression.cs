using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Leadership.Attribute
{
    [CreateAssetMenu(menuName = "Leadership Project/LeadershipProgression")]
    public class LeadershipProgression : ScriptableObject
    {
        [SerializeField] ProgressionLeadershipLevel[] progressionLeadershipLevels;
        
        
        Dictionary<int, Dictionary<LeadershipEnum,float>> progressionTableLookUp = null;

        public float GetRequireStat(LeadershipEnum leadershipEnum,int levelLead)
        {
            BuildLookupTable();

            return progressionTableLookUp[levelLead][leadershipEnum];
        }

        public Dictionary<LeadershipEnum,float> GetAllStat(int levelLead)
        {
            BuildLookupTable();
            
            if(levelLead >= 6)
            {
                return null;
            }
            return progressionTableLookUp[levelLead];
        }
        public void BuildLookupTable()
        {
            if(progressionTableLookUp != null) return;

            progressionTableLookUp = new Dictionary<int, Dictionary<LeadershipEnum,float>>();

            foreach (ProgressionLeadershipLevel progressionLeadershipLevel in progressionLeadershipLevels)
            {
                var statLeadLookup = new Dictionary<LeadershipEnum,float>();

                foreach (LeadershipStat leadershipStat in progressionLeadershipLevel.leadershipStats)
                {
                    statLeadLookup[leadershipStat.leadershipEnum] = leadershipStat.requirementStat;
                }

                progressionTableLookUp[progressionLeadershipLevel.levelLeadership] = statLeadLookup;
            }
        }
    }

    [System.Serializable]
    class ProgressionLeadershipLevel
    {
        public int levelLeadership;
        public LeadershipStat[] leadershipStats;
    } 

    [System.Serializable]
    class LeadershipStat
    {
        public LeadershipEnum leadershipEnum;
        public float requirementStat;
    }

    
}
