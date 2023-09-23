using UnityEngine;
using UnityEngine.UI;
using Leadership.Core;

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


        private void Awake()
        {
            actionPlay = GetComponent<ActionPlay>();    
        }
        private void Update()
        {
            if(plannedAction == null) return;

            if(plannedActionDaysDeadline == 0)
            {
                actionPlay.ActionStart();
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

        public void DecreaseDay()
        {
            if (plannedAction == null) return;
            plannedActionDaysDeadline -= 1;
        }

        
    }
}