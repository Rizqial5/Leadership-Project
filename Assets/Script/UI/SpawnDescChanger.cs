using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Leadership.Core;


namespace Leadership.UI
{
    public class SpawnDescChanger : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI statusObejct;
        [SerializeField] private string descItem;
        [SerializeField] DivisionEnum divisionEnum;

        private LeadershipMechanic leadershipMechanic;

        void Start()
        {
            leadershipMechanic = FindObjectOfType<LeadershipMechanic>();
        }
        public string ChangeStatus(string text)
        {
            return statusObejct.text = text;
        }

        public string ChangeDesc(string text)
        {
            descItem = text;
            SpawnActionTag spawnActionTag = GetComponent<SpawnActionTag>();

            return spawnActionTag.ChangeDesc(descItem); 
            
        }

        public DivisionEnum SetDivisionEnum(DivisionEnum value)
        {
            return divisionEnum = value;
        }

        public void SetLeaderDivisionMeeting()
        {
            leadershipMechanic.SetMeetingDivision(divisionEnum);
        }

        

        
    }
}
