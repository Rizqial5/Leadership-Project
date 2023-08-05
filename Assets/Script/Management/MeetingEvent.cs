using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using Leadership.UI;

namespace Leadership.Management
{
    public class MeetingEvent : MonoBehaviour
    {
        [SerializeField] MeetingEventSO[] meetingEvents;
        [SerializeField] DecisionEventUI decisionEventUI;
        [SerializeField] float waitTimeUntilEvents = 2f;
        [SerializeField] float beda = 1f;

        private bool isDoneJoinMeeting;
        

        private int i;

        public IEnumerator StartEvent()
        {
            yield return new WaitForSeconds(waitTimeUntilEvents);

            
            // FindObjectOfType<LeaderTag>().gameObject.SetActive(false);

            ShowMeetingEvent();
        }

        public void ShowMeetingEvent()
        {
            // if(Input.GetKeyDown(KeyCode.Q))
            if(isDoneJoinMeeting == true) return;

            decisionEventUI.gameObject.SetActive(true);

            
            int randomNumber = Random.Range(0,meetingEvents.Length);
            
            decisionEventUI.SetHeaderText(meetingEvents[randomNumber].MeetingEventName);
            decisionEventUI.SetStoryText(meetingEvents[randomNumber].MeetingEventDesc);

            AnswerCaseMeeting[] answerCaseMeetings = null;

            answerCaseMeetings = meetingEvents[randomNumber].GetCaseAnswers();

            foreach (AnswerCaseMeeting ansCase in answerCaseMeetings)
            {
                decisionEventUI.SpawnButton(ansCase.GetNameDesc(),i,beda, ansCase.GetCaseEffects());
                i++;
            }
            i = 0;
        }

        public GameObject GetDecisionEventUI()
        {
            return decisionEventUI.gameObject;
        }

        

        
    }
}
