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
        [SerializeField] DivisionEnum divisionEnum;
        [SerializeField] float waitTimeUntilEvents = 2f;
        [SerializeField] float beda = 1f;

        private bool isDoneJoinMeeting;

        private TrialScript cameraBehaviour;
        

        private int i;


        private void Awake()
        {
            cameraBehaviour = FindObjectOfType<TrialScript>();
        }

        // public IEnumerator StartEvent()
        // {
        //     yield return new WaitForSeconds(waitTimeUntilEvents);


        //     // FindObjectOfType<LeaderTag>().gameObject.SetActive(false);

        //     ShowMeetingEvent();
        // }

        public IEnumerator StartEvent(DivisionEnum setDivisionEnum)
        {
            yield return new WaitForSeconds(waitTimeUntilEvents);


            // FindObjectOfType<LeaderTag>().gameObject.SetActive(false);

            cameraBehaviour.SetCameraStop(true);
            ShowMeetingEvent(setDivisionEnum);
        }

        public void ShowMeetingEvent(DivisionEnum setDivisionEnum)
        {
            // if(Input.GetKeyDown(KeyCode.Q))
            if(isDoneJoinMeeting == true) return;

            decisionEventUI.gameObject.SetActive(true);

            
            int randomNumber = Random.Range(0,meetingEvents.Length);
            
            decisionEventUI.SetHeaderText(meetingEvents[randomNumber].MeetingEventName);
            decisionEventUI.SetStoryText(meetingEvents[randomNumber].MeetingEventDesc);
            decisionEventUI.SetImage(meetingEvents[randomNumber].GetImageIllustration());


            AnswerCaseMeeting[] answerCaseMeetings = null;

            answerCaseMeetings = meetingEvents[randomNumber].GetCaseAnswers();

            foreach (AnswerCaseMeeting ansCase in answerCaseMeetings)
            {   
                decisionEventUI.SpawnButton(ansCase.GetNameDesc(),i,beda, ansCase.GetCaseEffects(),ansCase.GetCaseOrgEffects(),setDivisionEnum);
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
