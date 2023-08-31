using System.Collections;
using System.Collections.Generic;
using Leadership.Core;
using UnityEngine;

namespace Leadership.Management
{
    public class StartMeeting : BaseState
    {
        protected MeetingSM _meetingSM;
        public StartMeeting(MeetingSM stateMachine) : base("StartMeeting", stateMachine)
        {
            _meetingSM = (MeetingSM) stateMachine;
        }


        public override void Enter()
        {
            base.Enter();

            _meetingSM.GetStatusScript().ChangeStatus("Meeting in Progress");
        }
        public override void UpdateLogic()
        {
            base.UpdateLogic();

            // if(_meetingSM.GetMeetingSystem().GetCalenderTime() > _meetingSM.StartMeeting()  )
            // {
            //     _meetingSM.ChangeState(_meetingSM.doneMeetingState);
            // }

            //Start Time Mechanic Changes

            if(_meetingSM.GetStartMeetingTime() < _meetingSM.GetMeetingSystem().GetStartMeetingNow())
            {
                _meetingSM.ChangeState(_meetingSM.doneMeetingState);
                _meetingSM.PrintString("bisa");
            }

            if(_meetingSM.GetGameSM().GetCurrentState() == _meetingSM.GetGameSM().pauseState)
            {
                _meetingSM.ChangeState(_meetingSM.pauseMeetingState);
            }

            
            // _meetingSM.GetLoadingText().SetActive(true);
            // _meetingSM.SetLoadingText("Meeting in Progress");
            _meetingSM.AddCloseEventButton();
            _meetingSM.StillPoisiton();
            _meetingSM.ShowStatusLeader();

            

            
        }

        public override void Exit()
        {
            base.Exit();

            // _meetingSM.SaveOldState(this);
        }

        





        


    }
}
