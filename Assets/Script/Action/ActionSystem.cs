using UnityEngine;
using UnityEngine.UI;
using Leadership.Core;
using Leadership.Attribute;

namespace Leadership.Action
{


    public class ActionSystem : MonoBehaviour 
    {
        [SerializeField] ActionSO[] actionItem;
        [SerializeField] DivisionEnum divisionEnum;


        [Header("Action Planned")]
        [SerializeField] ActionSO plannedAction;
        [SerializeField] private int plannedActionDaysDeadline;



        private ActionPlay actionPlay;
        private LeadershipMechanic leadershipMechanic;
        private AttributesMechanic attributesMechanic;


        private void Awake()
        {
            actionPlay = GetComponent<ActionPlay>();
            leadershipMechanic = FindObjectOfType<LeadershipMechanic>();
            attributesMechanic = FindObjectOfType<AttributesMechanic>();
        }
        private void Update()
        {
            if(plannedAction == null) return;

            if(plannedActionDaysDeadline == 0)
            {
                actionPlay.ActionStart(plannedAction);
            }
            
        }

        public ActionSO[] GetActionSO()
        {
            return actionItem;
        }

        internal DivisionEnum GetDivisionEnum()
        {
            return divisionEnum;
        }

        public void SetChosenAction(ActionSO actionItemTemp)
        {
            //Check persyaratan action so apakah sudah bisa
            
            plannedAction = actionItemTemp;

            plannedActionDaysDeadline = plannedAction.GetRequirementDay();
            
     
        }

        public void SetNullPlannedAction() { plannedAction = null; }
        public void EffectActivated()
        {
            if (plannedAction == null) return;

            if(plannedAction.GetLeadershipEffects() != null)
            {
                foreach (var item in plannedAction.GetLeadershipEffects())
                {
                    leadershipMechanic.AddEachMemberAttribute(item.GetLeadershipEnum(), item.GetValue());
                }
            }
            
            if(plannedAction.GetOrganizationEffects() != null)
            {
                foreach (var item in plannedAction.GetOrganizationEffects())
                {
                    attributesMechanic.AddAttributes(item.GetOrganisation(), item.GetValue());
                }
            }
            
        }

        public void DecreaseDay()
        {
            if (plannedAction == null) return;
            plannedActionDaysDeadline -= 1;
        }

        

        
    }
}