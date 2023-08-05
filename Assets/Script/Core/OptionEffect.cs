using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leadership.Management;
using Leadership.Attribute;

namespace Leadership.Core
{
    public class OptionEffect : MonoBehaviour
    {

        [SerializeField] bool isAdded;
        Dictionary<LeadershipEnum,float> effectOption;

        

        public void SetEffect(CaseEffect[] caseEffect)
        {
            BuildLookup();

            for (int i = 0; i < caseEffect.Length; i++)
            {
                effectOption[caseEffect[i].leadershipEnum] = caseEffect[i].effectAttribute;
                isAdded = true;
            }
        }

        public void BuildLookup()
        {
            if(effectOption != null) return;

            effectOption = new Dictionary<LeadershipEnum, float>();
        }

        public void EffectActive()
        {
            BuildLookup();

            LeadershipMechanic leadershipMechanic = FindObjectOfType<LeadershipMechanic>();

            foreach (var item in effectOption)
            {
                //Changed in the future just test
                
                
                leadershipMechanic.AddEachMemberAttribute(item.Key,item.Value);
                print(item.Key + " Effect has been activated total " + item.Value);
            }
        }
    
    }
}
