using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leadership.Attribute;

namespace Leadership.Management
{
    
    
    [CreateAssetMenu(fileName = "MeetingEventSO", menuName = "Leadership Project/MeetingEventSO", order = 0)]
    public class MeetingEventSO : ScriptableObject 
    {
        [SerializeField] string meetingEventName;

        [TextArea(3,10)]
        [SerializeField] string meetingEventDescription;

        [SerializeField] AnswerCaseMeeting[] caseAnswers; 

        [SerializeField] Sprite illustrationImage;  

        public string MeetingEventName
        {
            get{return meetingEventName;}
        }

        public string MeetingEventDesc
        {
            get{return meetingEventDescription;}
        }

        public AnswerCaseMeeting[] GetCaseAnswers()
        {
            return caseAnswers;
        } 

        public Sprite GetImageIllustration()
        {
            return illustrationImage;
        } 
        
    }

    [System.Serializable]
    public class AnswerCaseMeeting
    {
        [TextArea(2,5)]
        [SerializeField] string nameDes;
       
        public CaseEffect[] caseEffects; 
        //Option effect

        public string GetNameDesc()
        {
            return nameDes;
        }

        public CaseEffect[] GetCaseEffects()
        {
            return caseEffects;
        }
    }

    [System.Serializable]
    public class CaseEffect
    {
        public LeadershipEnum leadershipEnum;
        public float effectAttribute;
    }
}
