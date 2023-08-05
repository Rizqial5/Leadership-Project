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
        [SerializeField] int startMeetingTime;
        [SerializeField] string DescMeeting;
        [SerializeField] TextMeshProUGUI DescText;
        [SerializeField] TextMeshProUGUI startMeetingTtimeText;
        [SerializeField] TextMeshProUGUI EffectText;
        
        private MeetingSystem meetingSystem;
        private string effectMeeting;

        

        public void ShowPlan()
        {
            
            DescText.text = DescMeeting;

            //Effect Desc Change
            //EffectText.text = effectMeeting
            startMeetingTtimeText.text = "Day " + startMeetingTime.ToString();
        }

        public string GetStartMeeting()
        {
            return startMeetingTime.ToString();
        }

        public void MakePlan()
        {
           meetingSystem = FindObjectOfType<MeetingSystem>();
           meetingSystem.startTimeTemp = startMeetingTime;
           meetingSystem.meetingCategoryTemp = categoryMeeting.ToString();
        }

        
    }
   public enum CategoryMeetingEnum
   {
        Regular,
        Big
   } 
}
