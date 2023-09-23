using Leadership.Attribute;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Leadership.Action
{
    public class ActionItem : MonoBehaviour
    {
        private Dictionary<LeadershipEnum, float> leadershipEffect;
        private Dictionary<OrganisationEnum, float> organizationEffect;

        [SerializeField] private ActionSO actionSO;
        [SerializeField] private DivisionEnum division;


        public void SetActionSO(ActionSO item)
        {
            actionSO = item;

            division = item.GetDivisionEnum();
        }

        
        public void SetLeadershipEffectItem(LeadershipEnum item, float value)
        {
            leadershipEffect.Add(item,value);
        }
        public void SetOrganizationEffectItem(OrganisationEnum item, float value) { organizationEffect.Add(item,value); }

        public void ChooseActionSO()
        {
            FindObjectOfType<ActionDatabase>().SetActionItemTemp(actionSO);
        }
        
        

    }



}
