using System.Collections;
using System.Collections.Generic;
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
            //_meetingSM.AttributesMechanic().AddAttributes(Attribute.OrganisationEnum.Activity,5);
            //_meetingSM.AttributesMechanic().AddAttributes(Attribute.OrganisationEnum.Performance,5);

            

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
