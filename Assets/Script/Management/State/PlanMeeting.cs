using System.Collections;
using System.Collections.Generic;
using Leadership.Core;
using UnityEngine;

namespace Leadership.Management
{
    public class PlanMeeting : BaseState
    {
        protected MeetingSM _meetingSM;
        public PlanMeeting(MeetingSM stateMachine) : base("PlanMeeting", stateMachine)
        {
            _meetingSM = (MeetingSM)stateMachine;
        }

      

        public override void UpdateLogic()
        {
            base.UpdateLogic();

           if(_meetingSM.GetGameSM().GetCurrentState() == _meetingSM.GetGameSM().playState)
           {
                _meetingSM.ChangeState(_meetingSM.beginMeetingState);
           }

           _meetingSM.PrintCurrentState();
        }



        
    }
}
