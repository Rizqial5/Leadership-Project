using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using Leadership.UI;

namespace Leadership.Management
{
    public class Manage : MonoBehaviour
    {
        
        [SerializeField] GameObject interactionMenu;
        
        //Atribute------
        [SerializeField] TextMeshPro titleText;
        [SerializeField] string roomName;
        [SerializeField] DivisionEnum divisionEnum;
        [SerializeField] int meetingLimit = 1;
        [SerializeField] GameObject MeetingUI;
        // [SerializeField] GameObject loadingText;

        private int meetingCountTotal;
        private int startMeetingDate;
        
        private string statusNow;

        //Mengatur apakah leader join meeting
        private bool isLeaderJoinMeeting;


        
        private Color colorSementara;
        private Color colorTextSementara;
        private SpriteRenderer spriteImage;
        private RoomDesc roomNameDesc;
        private int startTimeMeeting;

        private void Awake() 
        {
            roomNameDesc = interactionMenu.GetComponent<RoomDesc>();
        }
        
        // Start is called before the first frame update
        void Start()
        {
            spriteImage = GetComponent<SpriteRenderer>();
            colorSementara = spriteImage.color;
            colorTextSementara = titleText.color;
            
        }

        // Update is called once per frame
        void Update()
        {

            
            if(Input.GetMouseButtonDown(0))
            {
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

                RaycastHit2D hit = Physics2D.Raycast(mousePos2D,Vector2.zero);
                
            }

            if(meetingCountTotal >= 1)
            {
                statusNow = "Occupied";
                return;
            }
            statusNow = "Empty";

        }

        private void OnMouseDown() {

            if(EventSystem.current.IsPointerOverGameObject()) return;
            if(interactionMenu.activeInHierarchy == false)
            {
                interactionMenu.SetActive(true);
                roomNameDesc.roomTitleText(roomName);
                
                roomNameDesc.GetComponent<InteractionScript>().SetDivisionEnum(divisionEnum);
                roomNameDesc.StatusText = statusNow;

                
                
            }
            else if(interactionMenu.activeInHierarchy == true )
            {
                interactionMenu.SetActive(false);

                if(MeetingUI.GetComponent<MenuSetting>().CheckActiveObject() == false) return;
                
                MeetingUI.GetComponent<MenuSetting>().SetActiveObject(false);
            }
            
            
            
            
        }

        private void OnMouseOver() {
            if(EventSystem.current.IsPointerOverGameObject()) return;
            spriteImage.color = new Color(0.962f,0.902f,0.92f,0.349f);
            titleText.color = new Color(titleText.color.r,titleText.color.g,titleText.color.b,1);
            
        }

        private void OnMouseExit() {
            if(EventSystem.current.IsPointerOverGameObject()) return;
            spriteImage.color = colorSementara;
            titleText.color = colorTextSementara;
            
           
        }

        public int meetingTotal
        {
            get{return meetingCountTotal;} set{meetingCountTotal = value;}
        }

        public int startMeetingDay
        {
            get{return startMeetingDate;} set{startMeetingDate = value;}
        }

        public int startMeetingTime
        {
            get{return startTimeMeeting;} set{startTimeMeeting = value;}
        }

        public int GetMeetingLimit()
        {
            return meetingLimit;
        }

        // public GameObject GetLoadingText()
        // {
        //     return loadingText;
        // }

        // public string SetGameObjectText(string text)
        // {
        //     return loadingText.GetComponent<TextMeshPro>().text = text;
        // }
        
        public DivisionEnum GetDivisionEnum()
        {
            return divisionEnum;
        }
        public string roomNameGet()
        {
            return roomName;
        }



        ///Leader behaviour Function
        public bool SetLeaderIsMeeting(bool value)
        {
            return isLeaderJoinMeeting = value;
        }
        public bool GetLeaderIsMeeting()
        {
            return isLeaderJoinMeeting;
        }

        

    
       
    }
}
