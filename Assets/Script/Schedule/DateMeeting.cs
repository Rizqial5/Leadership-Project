using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Leadership.Schedule
{
    public class DateMeeting : MonoBehaviour
    {
        [SerializeField] StatusDate statusDate; 
        [SerializeField] int day;
        private Image image;
        private int dayChosen;
        
        private GameObject parent;

        
        void Awake()
        {
            image = GetComponent<Image>();
            parent = transform.parent.gameObject;

        }
        private void Update() 
        {
            if(statusDate == StatusDate.Occupied)
            {
                image.color = Color.red;
            }
        }
        
        
        public void TakeDate()
        {
            
            if(image.color != Color.red)
            {
                if(parent.GetComponent<CalenderMeeting>().GetIsThereOccupied() == true) return;

                image.color = Color.red;
                statusDate = StatusDate.Occupied;
                dayChosen = day;
            } 
            else if(image.color == Color.red)
            {
                image.color = Color.white;
                statusDate = StatusDate.Free;
                dayChosen = 0;
                
                parent.GetComponent<CalenderMeeting>().SetIsThereOccupied(false);
            }
            
        }

        public StatusDate GetStatus()
        {
            return statusDate;
        }

        public int GetDayChosen()
        {
            return dayChosen;
        }
    }
}
