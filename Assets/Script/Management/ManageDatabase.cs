using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Leadership.Management
{

    

    public class ManageDatabase : MonoBehaviour
    {

        [SerializeField] Manage[] totalInteractionRooms;
        [SerializeField] List<MeetQueue> meetingsInQueue;
        

        private int _meetingTotal;
        private int _meetingLimit;
        private int _startMeetingDate;
        private bool isLeaderJoinMeeting;


        public string GetName( DivisionEnum name)
        {
            foreach (Manage item in totalInteractionRooms)
            {
                if(item.GetDivisionEnum() == name)
                {
                    return item.roomNameGet();
                }
            }

            return null;
        }

        public int GetMeetingCount(DivisionEnum name)
        {
            foreach (Manage item in totalInteractionRooms)
            {
                if(item.GetDivisionEnum() == name)
                {
                    return item.meetingTotal;
                }
            }

            return 0;
        }

        public int GetMeetingLimit(DivisionEnum name)
        {
            foreach (Manage item in totalInteractionRooms)
            {
                if(item.GetDivisionEnum() == name)
                {
                    return item.GetMeetingLimit();
                }
            }

            return 0;
        }


        public int SetMeetingCount(DivisionEnum name, int number)
        {
            foreach (Manage item in totalInteractionRooms)
            {
                if(item.GetDivisionEnum() == name)
                {
                    item.meetingTotal += number;
                }
            }

            return 0;
        }

        public int SetStartMeetingDate(DivisionEnum name, int number)
        {
            foreach (Manage item in totalInteractionRooms)
            {
                if(item.GetDivisionEnum() == name)
                {
                    item.startMeeting += number;
                }
            }

            return 0;
        }

        public bool SetIsLeaderJoinMeeting(DivisionEnum name, bool value)
        {
            foreach (Manage item in totalInteractionRooms)
            {
                if(item.GetDivisionEnum() == name)
                {
                    return item.SetLeaderIsMeeting(value);
                }
            }

            return false;
        }

        public bool GetIsLeaderJoinMeeting(DivisionEnum name, bool value)
        {
            foreach (Manage item in totalInteractionRooms)
            {
                if(item.GetDivisionEnum() == name)
                {
                    return item.GetLeaderIsMeeting();
                }
            }

            return false;
        }

        // public void SetMeetQueue(DivisionEnum divisionName, string nameMeeting, int timeMeeting)
        // {
        //     meetingsInQueue.Add();
        // }



    
    }

    public class MeetQueue
    {
        DivisionEnum divisionEnum;
        string meetName;
        int meetingTime;
    }
}