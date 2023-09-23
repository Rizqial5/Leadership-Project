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
        [SerializeField] private string reqDesc;
        [SerializeField] private Dictionary<string, float> effectDesc;
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

        public string ChangeReqDesc(string text)
        {
            reqDesc = text;

            SpawnActionTag spawnActionTag = GetComponent<SpawnActionTag>();

            return spawnActionTag.ChangeReq(reqDesc);
        }

        public Dictionary<string,float> ChangeEffectDesc(Dictionary<string,float> text)
        {
            effectDesc = text;

            SpawnActionTag spawnActionTag = GetComponent<SpawnActionTag>();

            return spawnActionTag.ChangeEffect(effectDesc);
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
