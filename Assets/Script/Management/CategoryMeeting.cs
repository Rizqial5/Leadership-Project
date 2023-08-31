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
        [SerializeField] TextMeshProUGUI startMeetingTimeText;
        [SerializeField] TextMeshProUGUI EffectText;
        
        private MeetingSystem meetingSystem;
        private string effectMeeting;
        
        void Awake()
        {
            meetingSystem = FindObjectOfType<MeetingSystem>();
        }
        void Update()
        {
            startMeetingTimeText.text = meetingSystem.GetStartMeetingTime().ToString();
        }

        public void ShowPlan()
        {
            
            DescText.text = DescMeeting;

            //Effect Desc Change
            //EffectText.text = effectMeeting
            startMeetingDayText.text = startMeetingDay.ToString();
        }

        public string GetStartMeetingDay()
        {
            return startMeetingDay.ToString();
        }

        public void MakePlan()
        {
           
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
