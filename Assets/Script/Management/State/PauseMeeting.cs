using System.Collections;
using System.Collections.Generic;
using Leadership.Core;
using UnityEngine;

namespace Leadership.Management
{
    public class PauseMeeting : BaseState
    {
        protected MeetingSM _meetingSM;
        public PauseMeeting(MeetingSM stateMachine) : base("PauseMeeting", stateMachine)
        {
            _meetingSM = (MeetingSM)stateMachine;
        }

        public override void Enter()
        {
            base.Enter();

           
        }
        public override void UpdateLogic()
        {
            base.UpdateLogic();

            
            _meetingSM.AddCloseEventButton();

            
            if(_meetingSM.GetGameSM().GetCurrentState() == _meetingSM.GetGameSM().playState)
            {
                _meetingSM.ChangeState(_meetingSM.beginMeetingState);
            }

            if(_meetingSM.GetMeetingUI() == null) return;
            _meetingSM.StillPoisiton();
        }





        

        
    }
}
