using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Leadership.Management
{
    public class CategoryMeeting : MonoBehaviour
    {
        // Start is called before the first frame update
        [SerializeField] CategoryMeetingEnum categoryMeeting;
        [SerializeField] int startMeetingDay;
        [SerializeField] string DescMeeting;
        [SerializeField] TextMeshProUGUI DescText;
        [SerializeField] TextMeshProUGUI startMeetingDayText;
        [SerializeField] TextMeshProUGUI EffectText;
        
        private MeetingSystem meetingSystem;
        private string effectMeeting;

        

        public void ShowPlan()
        {
            
            DescText.text = DescMeeting;

            //Effect Desc Change
            //EffectText.text = effectMeeting
            startMeetingDayText.text = "Day " + startMeetingDay.ToString();
        }

        public string GetStartMeetingDay()
        {
            return startMeetingDay.ToString();
        }

        public void MakePlan()
        {
           meetingSystem = FindObjectOfType<MeetingSystem>();
           meetingSystem.startDayTemp = startMeetingDay;
           meetingSystem.meetingCategoryTemp = categoryMeeting.ToString();
        }

        
    }
   public enum CategoryMeetingEnum
   {
        Regular,
        Big
   } 
}
