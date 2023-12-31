using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
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
            _meetingSM.SetBooleanPause(false);
            
        }
        public override void UpdateLogic()
        {
            base.UpdateLogic();

            // if(_meetingSM.GetMeetingSystem().GetCalenderTime() > _meetingSM.StartMeeting()  )
            // {
            //     _meetingSM.ChangeState(_meetingSM.doneMeetingState);
            // }

            //Start Time Mechanic Changes

            if(_meetingSM.GetStartMeetingTime() < _meetingSM.GetMeetingSystem().GetStartMeetingNow() )
            {
                
                _meetingSM.ChangeState(_meetingSM.doneMeetingState);
                _meetingSM.PrintString("bisa");
            }

            if(_meetingSM.GetMeetingSystem().GetStartMeetingNow() == 3)
            {
                _meetingSM.StartTimed(2f);
            }

            if(_meetingSM.GetGameSM().GetCurrentState() == _meetingSM.GetGameSM().pauseState)
            {
                _meetingSM.SetBooleanPause(true);
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

           

            if (_meetingSM.GetManage().GetPlannedMeetingCategory() == "Event" && !_meetingSM.GetBoolPause()) 
            {
                _meetingSM.GetActionSystem().AddCountedTimeMeeting();
                //_meetingSM.GetCurrentState();
                //_meetingSM.PrintString("masuk" + _meetingSM.GetManage().GetPlannedMeetingCategory());
                
            }
            // _meetingSM.SaveOldState(this);
        }

        





        


    }
}
