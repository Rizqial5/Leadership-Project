using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Leadership.Schedule
{
    public class CalenderMeeting : MonoBehaviour
    {
        [SerializeField] DateMeeting[] dateCalendar;
        private int occupiedCount;
        private bool isThereOccupied;
        private int dateChosen;
    
        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            foreach (DateMeeting dateMeeting in dateCalendar)
            {
                if(dateMeeting.GetStatus() == StatusDate.Occupied)
                {
                    isThereOccupied = true;
                    dateChosen = dateMeeting.GetDayChosen();
                    
                }
                
            }

            
            
        }

        public bool GetIsThereOccupied()
        {
            return isThereOccupied;
        }

        public bool SetIsThereOccupied(bool a)
        {
            return isThereOccupied = a;
        }

        public int GetDateChosen()
        {
            return dateChosen;
        }

        
    }
}
