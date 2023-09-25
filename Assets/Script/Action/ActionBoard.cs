using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Leadership.UI;
using Leadership.Core;

namespace Leadership.Action
{
    public class ActionBoard : MonoBehaviour
    {
        [SerializeField] PanelBoard actionBoardPanel;
        [SerializeField] Transform parentSpawn;

        private TurnSystem turnSystem;
        private ActionSystem[] actionSystem;

        private void Awake()
        {
            turnSystem = FindObjectOfType<TurnSystem>();
            actionSystem = FindObjectsOfType<ActionSystem>();
        }


        public void ShowActionBoard()
        {
            List<ActionSO> totalActions = GetComponent<ActionDatabase>().GetTotalActionSO();

            List<string> totalItems = new List<string>();
            List<string> totalDesc = new List<string>();

            foreach (var item in totalActions)
            {
                totalItems.Add(item.GetNameAction());

                

                int countedMeetingReq = item.GetTotalMeetingReq() ;
                int countedMeetingNow = GetCountedMeetingFromActionSystem(item.GetDivisionEnum());
                int remainingDays = item.GetRequirementDay() - GetCountedDayFromActionSystem(item.GetDivisionEnum());
                 
                totalDesc.Add( "Hari Persiapan : " + remainingDays + "\n" + 
                    "Meeting yang dilaksanakan : " + countedMeetingNow.ToString() + " / " + countedMeetingReq.ToString());
            }

            string[] totalActionName = totalItems.ToArray();
            string[] totalDescAction = totalDesc.ToArray();



            PanelBoard spawnPanelBoard = Instantiate(actionBoardPanel, parentSpawn);
            
            spawnPanelBoard.windowTitle.text = "Action Board";
            spawnPanelBoard.SpawnObjectList(totalActionName, totalDescAction, "Persyaratan Progress : ");
        }

        public int GetCountedMeetingFromActionSystem(DivisionEnum divisionEnum)
        {
            foreach (var item in actionSystem)
            {
                if (divisionEnum == item.GetDivisionEnum()) 
                {
                    return item.GetCountedMeeting();
                }
            }

            return 0;
        }

        public int GetCountedDayFromActionSystem(DivisionEnum divisionEnum)
        {
            foreach (var item in actionSystem)
            {
                if (divisionEnum == item.GetDivisionEnum())
                {
                    return item.GetCountedDays();
                }
            }

            return 0;
        }


    }
}

