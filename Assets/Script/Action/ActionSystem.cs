using UnityEngine;
using UnityEngine.UI;
using Leadership.Core;
using Leadership.Attribute;
using Leadership.Management;

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
        private ManageDatabase manageDB;
        [SerializeField] private int countedTimeMeeting;
        [SerializeField] private int countedDaysSincePlan;


        private void Awake()
        {
            actionPlay = GetComponent<ActionPlay>();
            leadershipMechanic = FindObjectOfType<LeadershipMechanic>();
            attributesMechanic = FindObjectOfType<AttributesMechanic>();
            manageDB= FindObjectOfType<ManageDatabase>();
        }
        private void Update()
        {
            if(plannedAction == null) return;

            if(plannedActionDaysDeadline == 0)
            {
                if (countedTimeMeeting < plannedAction.GetTotalMeetingReq())
                {
                    print("Meeting Gagal dilaksanakan");
                    return;
                }
                actionPlay.ActionStart(plannedAction);
            }
            
        }

        public ActionSO[] GetActionSO()
        {
            return actionItem;
        }

        public int GetCountedMeeting()
        {
            return countedTimeMeeting;
        }

        public int GetCountedDays()
        {
            return countedDaysSincePlan;
        }

        public void AddCountedDays()
        {
            if (plannedAction == null) return ;

            countedDaysSincePlan++ ;
        }

        public void AddCountedTimeMeeting()
        {
            if (plannedAction == null) return;
            countedTimeMeeting++;
        }

        internal DivisionEnum GetDivisionEnum()
        {
            return divisionEnum;
        }

        public void SetChosenAction(ActionSO actionItemTemp)
        {
            
            
            plannedAction = actionItemTemp;

            manageDB.SetMeetingDesc(divisionEnum, "Meeting ini akan mempersiapkan kegiatan " + plannedAction.GetNameAction());

            plannedActionDaysDeadline = plannedAction.GetRequirementDay();
            
     
        }

        public ActionSO GetPlannedAction()
        {
            return plannedAction;
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