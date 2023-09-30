using System.Collections;
using System.Collections.Generic;
using Leadership.Attribute;
using Leadership.Core;
using UnityEngine;

namespace Leadership.Management
{
    public class DoneMeeting : BaseState
    {
        protected MeetingSM _meetingSM;
        public DoneMeeting(MeetingSM stateMachine) : base("DoneMeeting", stateMachine)
        {
            _meetingSM = (MeetingSM) stateMachine;
        }

        public override void Enter()
        {
            //Add check performance
            float penalty = 0;
            if (_meetingSM.AttributesMechanic().CheckPerformance())
            {
                _meetingSM.PrintString("Penalty performance");
                penalty = -5;
            }

            _meetingSM.AttributesMechanic().AddAttributes(OrganisationEnum.Activity, 5 + penalty);
            _meetingSM.AttributesMechanic().AddAttributes(OrganisationEnum.Performance, 10 + penalty);



        }
        public override void UpdateLogic()
        {
            base.UpdateLogic();

            // _meetingSM.GetLoadingText().SetActive(false);
            _meetingSM.DestroySpawnMeeting();
            
            _meetingSM.SetMeetingTotal(0) ;
            _meetingSM.SetMeetingTime(0);
            
            

            
            _meetingSM.ChangeState(_meetingSM.planMeetingState);
            

           
        }

        
    }
}
