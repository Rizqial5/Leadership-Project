using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Leadership.Core;
using Leadership.UI;
using Leadership.Attribute;

namespace Leadership.Management
{
    public class MeetingSystem : MonoBehaviour
    {
        
        [SerializeField] TurnSystem turnSystem;
        
        

        


        
        
        private int startDaySementara;
        private int startMeetingTime;
        private int startMeetingTemp;
        private string meetingCategoryNameTemp;

        [SerializeField] private string meetingCategoryName;
        private SpawnObject[] statusMeetingUI;
        private DecisionEventUI decisionEventUI;
        private ManageDatabase _manageDatabase;
        private CategoryMeeting categoryMeeting;
        private AttributesMechanic attributesMechanic;
        private LeadershipMechanic leadershipMechanic;
        
        [SerializeField] private DivisionEnum _divisionEnum;
        [SerializeField] GameObject warningText;
        [SerializeField] GameObject statusLeader;

        [SerializeField] private string meetingEventDesc;


        private void Awake() 
        {
            _manageDatabase = GetComponent<ManageDatabase>();
            attributesMechanic = FindObjectOfType<AttributesMechanic>();
            leadershipMechanic = FindObjectOfType<LeadershipMechanic>();
        }
        
        // Start is called before the first frame update
        void Start()
        {

        }


        // Update is called once per frame
        void Update()
        {
            // print(startTimeTemp);
            // print(turnSystem.CalenderTime());
            // if(turnSystem.CalenderTime() != startMeeting) return;
            

            // if(turnSystem.IsPlay())
            // {
            //     loadingText.SetActive(true);
            //     //show loading meeting
            //     // timerMeeting += Time.deltaTime * turnSystem.GetSpeedModifier();
            // }
            // if(!turnSystem.IsPlay())
            // {
            //     loadingText.SetActive(false);
            //     //loading meeting closed
            //     // text close
                
            // }
            
            // print(startMeeting);

            statusMeetingUI = FindObjectsOfType<SpawnObject>();
            
            

            if(statusMeetingUI != null)
            {
                
                for (int i = 0; i < statusMeetingUI.Length; i++)
                {
                    if (statusMeetingUI[i].GetComponentInChildren<Button>() == null) continue;
                    statusMeetingUI[i].GetComponentInChildren<Button>().onClick.AddListener(() => SetStatusLeader());
                }
            }
            


            if (IsMeetingFull())
            {
                warningText.SetActive(true);
                return;
            }

            warningText.SetActive(false);
            
            
        }

        public int startDayTemp
        {
            get{return startDaySementara;} set{startDaySementara = value;}
        }
        
        public string meetingCategoryTemp
        { 
            get{return meetingCategoryNameTemp;} set{meetingCategoryNameTemp = value;}
        }

        public int GetCalenderTime()
        {
            return turnSystem.CalenderTime;
        }
        

        public DivisionEnum DivisionEnum
        {
           get{return _divisionEnum;} set{_divisionEnum = value;}
        }

        public void SetDescMeetingEvent()
        {
            
            meetingEventDesc = _manageDatabase.GetMeetingDesc(DivisionEnum);
            
            
        }

        public string GetDescMeetingEvent()
        {

            return meetingEventDesc; 


        }



        public void MeetingPlan()
        {
            if(meetingCategoryNameTemp == null) return;
            if(IsMeetingFull()) return;
            if(startMeetingTime == 0) return;

            //Add check activities rate
            if(attributesMechanic.CheckActivitiesRate())
            {
                print("Penalty");
                attributesMechanic.AddAttributes(OrganisationEnum.Unity, -10);
                leadershipMechanic.AddEachMemberAttribute(_divisionEnum, LeadershipEnum.Relation, -10);
            }
            
            _manageDatabase.SetMeetingCount(_divisionEnum, 1);
            
            _manageDatabase.SetStartMeetingDate(_divisionEnum,startDayTemp,startMeetingTime);
            _manageDatabase.SetMeetingCategoryPlanned(_divisionEnum, meetingCategoryNameTemp);

            meetingCategoryName = meetingCategoryNameTemp;
            



            //pada tanggal kapan meeting itu dilaksanakan


        }

        public bool IsMeetingFull()
        {
            return _manageDatabase.GetMeetingCount(_divisionEnum) >= _manageDatabase.GetMeetingLimit(_divisionEnum);
        }

        public int GetMeetingSlot()
        {
            return _manageDatabase.GetMeetingLimit(_divisionEnum);
        }

        
        public void CloseInteractionRoom()
        {
            if(!FindObjectOfType<RoomDesc>().gameObject.activeInHierarchy) return;

            FindObjectOfType<RoomDesc>().gameObject.SetActive(false);
        }

        



        public string GetNameMeeting()
        {
            return meetingCategoryName;
        }

        

        public void Testing()
        {
            print("connet");
        }

        public void SetStatusLeader()
        {
            _manageDatabase.SetIsLeaderJoinMeeting(_divisionEnum,true);
            // print(_divisionEnum);
            //function untuk apabila dipencet maka leader join rapat sesuai divisi yang mengadakan
            statusLeader.SetActive(true);
            
        }


//Meeting Time Mechanuc
        public void SelectTime(int value)
        {
            if(value == -1)
            {
                if(startMeetingTime == 0) return;
            }
            else if(value == 1)
            {
                if(startMeetingTime == 3) return;
            }

            startMeetingTime += value;
        }

        public int GetStartMeetingTime()
        {
            return startMeetingTime;
        }

        public int GetStartMeetingNow()
        {
            return turnSystem.GetTimeDay();
        }

        

        

        
    }
}
