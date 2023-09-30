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
        private ActionDatabase actionDatabase;
        [SerializeField] private int countedTimeMeeting;
        [SerializeField] private int countedDaysSincePlan;


        private void Awake()
        {
            actionPlay = GetComponent<ActionPlay>();
            leadershipMechanic = FindObjectOfType<LeadershipMechanic>();
            attributesMechanic = FindObjectOfType<AttributesMechanic>();
            manageDB= FindObjectOfType<ManageDatabase>();
            actionDatabase = FindObjectOfType<ActionDatabase>();
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
            countedTimeMeeting += 1;
        }

        internal DivisionEnum GetDivisionEnum()
        {
            return divisionEnum;
        }

        public void SetChosenAction(ActionSO actionItemTemp)
        {
            plannedAction = actionItemTemp;

            //Add check activities
            if (attributesMechanic.CheckActivitiesRate())
            {
                print("Penalty");
                attributesMechanic.AddAttributes(OrganisationEnum.Unity, -10);
                leadershipMechanic.AddEachMemberAttribute(plannedAction.GetDivisionEnum(), LeadershipEnum.Relation, -10);
            }

            

            manageDB.SetMeetingDesc(divisionEnum, "Meeting ini akan mempersiapkan kegiatan " + plannedAction.GetNameAction());

            plannedActionDaysDeadline = plannedAction.GetRequirementDay();
            
     
        }

        public ActionSO GetPlannedAction()
        {
            return plannedAction;
        }

        public void SetNullPlannedAction() 
        {
            actionDatabase.DeleteTotalAction(plannedAction);
            plannedAction = null; 
        }
        public void EffectActivated(float accumulationPoint)
        {
            if (plannedAction == null) return;

            float penalty = 0;

            //Add Check performance
            if(attributesMechanic.CheckPerformance())
            {
                penalty = -10;
            }

            plannedAction.RespawnActionTime = plannedAction.GetRespawnActionTimeLimit();

            if(plannedAction.GetLeadershipEffects() != null)
            {
                foreach (var item in plannedAction.GetLeadershipEffects())
                {
                    leadershipMechanic.AddEachMemberAttribute(item.GetLeadershipEnum(), item.GetValue() + accumulationPoint + penalty);
                }
            }
            
            if(plannedAction.GetOrganizationEffects() != null)
            {
                foreach (var item in plannedAction.GetOrganizationEffects())
                {
                    if(item.GetValue() < 0)
                    {
                        attributesMechanic.AddAttributes(item.GetOrganisation(), item.GetValue());
                    }else
                    {
                        attributesMechanic.AddAttributes(item.GetOrganisation(), item.GetValue() + accumulationPoint + penalty);
                    }
                    
                }
            }

            countedTimeMeeting = 0;
            countedDaysSincePlan = 0;
            
        }

        public void DecreaseDay()
        {
            if (plannedAction == null) return;
            plannedActionDaysDeadline -= 1;
        }

        public bool GetIsPLayAction()
        {
            return actionPlay.GetActionPLay();
        }

        

        
    }
}