using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leadership.Core;
using Leadership.UI;
using Leadership.Attribute;
using Leadership.Action;
using UnityEngine.UI;

namespace Leadership.Management
{
    public class MeetingSM : StateMachine
    {
        private MeetingSystem meetingSystem;
        [SerializeField] private string stateNow;
        [SerializeField] GameObject statusGameobject;
        [SerializeField] Transform positionStatus;
        [SerializeField] Transform parentSpawn;
        [SerializeField] GameObject statusLeaderUI;
        [SerializeField] MeetingEvent meetingEvent;
        [SerializeField] DecisionEventUI decisionEventUI;
        
        

        [HideInInspector] public BeginMeeting beginMeetingState;
        [HideInInspector] public PlanMeeting planMeetingState;
        [HideInInspector] public StartMeeting startMeetingState;
        [HideInInspector] public DoneMeeting doneMeetingState;
        [HideInInspector] public PauseMeeting pauseMeetingState;

        private GameSM gameSM;
        private GameObject loadingText;
        private Manage manageDB;
        private ActionSystem actionSystem;
        private TrialScript cameraScript;
        private int startMeetingDate;
        private GameObject MeetingUI; 
        private AttributesMechanic attributesMechanic;
        private GameObject statusRoomButton;
        
        

       

        private void Awake() 
        {
            beginMeetingState = new BeginMeeting(this);
            planMeetingState = new PlanMeeting(this); 
            gameSM = FindObjectOfType<GameSM>();
            startMeetingState = new StartMeeting(this);
            doneMeetingState = new DoneMeeting(this);  
            pauseMeetingState = new PauseMeeting(this); 

            meetingSystem = FindObjectOfType<MeetingSystem>();
            manageDB = GetComponent<Manage>();
            actionSystem = GetComponent<ActionSystem>();
            attributesMechanic = FindObjectOfType<AttributesMechanic>();
            cameraScript = FindObjectOfType<TrialScript>();

 
        }

        // private void Update() {
        //     stateNow = currentState.ToString();
        // }

        // public override void PlayButton()
        // {
        //     currentState = beginMeetingState;
        //     base.PlayButton();
            
        // }

        // public override void PauseButton()
        // {
        //     if(gameSM.IsPlanState()) return;
        //     base.PauseButton();
            

        //     currentState = pauseMeetingState;
        // }

        protected override BaseState GetInitialState()
        {
            return planMeetingState;
        }

        public void SaveOldState(BaseState state)
        {
            oldState = state;
        }

        public void SetStatusButton(bool active)
        {
            
            if (statusRoomButton == null) return;

            statusRoomButton.SetActive(active);
        }

        public void FindStatusButton()
        {
            statusRoomButton = GameObject.FindGameObjectWithTag("ToggledButton");
        }

        public MeetingSystem GetMeetingSystem()
        {
            return meetingSystem;
        }

        public TrialScript CameraSystem()
        { return cameraScript; }

        public Manage GetManage()
        { return manageDB; }

        public ActionSystem GetActionSystem() { return actionSystem; }  

        public GameSM GetGameSM()
        {
            return gameSM;
        }
        public MeetingEvent GetMeetingEvent()
        {
            return meetingEvent;
        }

        public AttributesMechanic AttributesMechanic()
        {
            return attributesMechanic;
        }


        //private void OnGUI()
        //{
        //    string content = currentState != null ? currentState.name : "(no current state)";
        //    GUILayout.Label($"<color='black'><size=40>{content}</size></color>");
        //}

        public void PrintString(string kata)
        {
            print(kata);
        }

        public int StartMeeting()
        {
            startMeetingDate = manageDB.startMeetingDay;

            return startMeetingDate;
        }

        // public GameObject GetLoadingText()
        // {
        //     loadingText = manageDB.GetLoadingText();
        //     return loadingText;
        // }

        // public string SetLoadingText(string text)
        // {
        //     return manageDB.SetGameObjectText(text);
        // }

        public void SpawnStatusUI()
        {
            
            MeetingUI = Instantiate(statusGameobject,positionStatus.transform.position,positionStatus.transform.rotation,parentSpawn);

            MeetingUI.GetComponentInChildren<Button>().onClick.AddListener(() => StartCoroutine(meetingEvent.StartEvent(manageDB.GetDivisionEnum())));
            MeetingUI.GetComponent<SpawnDescChanger>().SetDivisionEnum(manageDB.GetDivisionEnum());
            
        }

        public SpawnDescChanger GetStatusScript()
        {
            if(MeetingUI == null) return null;
            return MeetingUI.GetComponent<SpawnDescChanger>();
        }

        public void StillPoisiton()
        {
            MeetingUI.transform.position = positionStatus.transform.position;
        }

        public void DestroySpawnMeeting()
        {
            Destroy(MeetingUI);
        }

        public GameObject GetMeetingUI()
        {
            return MeetingUI;
        }

        public void PrintCurrentState()
        {
            stateNow = manageDB.startMeetingDay.ToString();
        }

        public int GetMeetingTotal()
        {
            return manageDB.meetingTotal;
        }
        public int SetMeetingTime(int value)
        {
            return manageDB.startMeetingDay = 0;
        }
        public int SetMeetingTotal(int value)
        {
            return manageDB.meetingTotal = value;
        }

        public void ShowStatusLeader()
        {
            // if(startMeetingDate == 0) return;
            // if(!manageDB.GetLeaderIsMeeting()) return;
            
            if(statusLeaderUI.activeInHierarchy == true)
            {
                gameSM.ChangeState(gameSM.pauseState);  
            } 
        }

        public void CloseEventUI()
        {
            
            gameSM.ChangeState(gameSM.playState);
            statusLeaderUI.SetActive(false);
            cameraScript.SetCameraStop(false);
   
            
        }

       
        public void AddCloseEventButton()
        {
            if(decisionEventUI.GetComponentsInChildren<Button>() == null) return;
            // print("true");
            Button[] ansButton = decisionEventUI.GetComponentsInChildren<Button>();

            for (int i = 0; i < ansButton.Length; i++)
            {
                ansButton[i].onClick.AddListener(() => CloseEventUI());
            }
        }

        public bool CheckDecisionUI()
        {
            return decisionEventUI.gameObject.activeSelf ;
            
        }

        //Start Meeting Mechanic
        public int GetStartMeetingTime()
        {
            return manageDB.startMeetingTime;
        }

        private IEnumerator StartMEetingTimed(float second)
        {
            yield return new WaitForSeconds(second);

            ChangeState(doneMeetingState);
        }

        public void StartTimed(float second)
        {
            StartCoroutine(StartMEetingTimed(second));
        }

        

    }   
}
