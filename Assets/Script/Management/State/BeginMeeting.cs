using System.Collections;
using System.Collections.Generic;
using Leadership.Core;
using Leadership.UI;
using UnityEngine;

namespace Leadership.Management
{
    public class BeginMeeting : BaseState
    {
        protected MeetingSM _meetingSM;
        public BeginMeeting(MeetingSM stateMachine) : base("BeginMeeting", stateMachine)
        {
            _meetingSM = (MeetingSM)stateMachine;
        }

        public override void Enter()
        {
            base.Enter();

            if(_meetingSM.GetMeetingTotal() == 0) return;
            if(_meetingSM.GetMeetingUI() != null) return;
            if(_meetingSM.StartMeeting() == 0) return;
            _meetingSM.SpawnStatusUI();

            

        }

        public override void UpdateLogic()
        {
            base.UpdateLogic();

            
            _meetingSM.GetStatusScript().ChangeStatus("Waiting....");

        

            if(_meetingSM.GetGameSM().GetCurrentState() == _meetingSM.GetGameSM().planState)
            {
                _meetingSM.ChangeState(_meetingSM.planMeetingState);
            }

            if(_meetingSM.GetGameSM().GetCurrentState() == _meetingSM.GetGameSM().pauseState)
            {
                _meetingSM.ChangeState(_meetingSM.pauseMeetingState);
            }

            

            if(_meetingSM.GetMeetingTotal() == 0) return;
            
            
            _meetingSM.StillPoisiton();

            _meetingSM.ShowStatusLeader();
            
            //dimodifikasi untuk sesuai dengan starttime terus jika harinya sama maka diganti prepare meeting
            if(_meetingSM.GetMeetingSystem().GetCalenderTime() == _meetingSM.StartMeeting())
            {
                _meetingSM.GetStatusScript().ChangeStatus("Prepare Meeting");

                if(_meetingSM.GetStartMeetingTime() == _meetingSM.GetMeetingSystem().GetStartMeetingNow())
                {
                    _meetingSM.ChangeState(_meetingSM.startMeetingState);
                }

                // _meetingSM.ChangeState(_meetingSM.startMeetingState);
                
            } 

            

            
            
            
            
            
        }

        public override void Exit()
        {
            base.Exit();

            // _meetingSM.PrintString("exit");
        }
    }
}
