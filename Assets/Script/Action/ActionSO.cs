using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leadership.Attribute;



namespace Leadership.Action
{
    [CreateAssetMenu(fileName = "Action Item", menuName = "Leadership Project/ActionSO", order = 0)]
    public class ActionSO : ScriptableObject 
    {
        [SerializeField] DivisionEnum divisionEnum;
        [SerializeField] ActionEnum actionEnum;

        [Header("Action Description")]
        [SerializeField] string nameAction;
        
        [TextArea(2,5)]
        [SerializeField] string descAction;
        [SerializeField] Sprite imageAction;

        [Header("Action Requirement")]
        [SerializeField] int actionRequirementDays;
        [SerializeField] int meetingTime;
        [SerializeField] float moneyRequirements;
        [SerializeField] SpecialRequirements[] specialRequirements;

        [Header("Action Effect")]
        [SerializeField] LeadershipEffect[] leadershipEffects;
        [SerializeField] OrganizationEffect[] organizationEffects;

        [SerializeField] ActionEventSO[] actionEventSOs;


        public string GetNameAction()
        {
            return nameAction;
        }

        public Sprite GetImageAction()
        {
            return imageAction;
        }

        public DivisionEnum GetDivisionEnum() { return divisionEnum; }

        public ActionEnum GetActionEnum()
        {
            return actionEnum;
        }

        public string GetDescAction()
        {
            return descAction;
        }

        public int GetRequirementDay()
        {
            return actionRequirementDays;
        }

        public int GetTotalMeetingReq()
        {
            return meetingTime;
        }

        public float GetMoneyRequirement()
        {
            return moneyRequirements;
        }

        public ActionEventSO[] GetActionEventSO()
        {
            return actionEventSOs;
        }

        public LeadershipEffect[] GetLeadershipEffects() { return leadershipEffects; }
        public OrganizationEffect[] GetOrganizationEffects() {  return organizationEffects; }

        //Effect umum dari action ini

        //Effect Khusus dari action ini berupa script sendiri
    }

    [System.Serializable]
    public class LeadershipEffect
    {
        [SerializeField] LeadershipEnum leadershipEnum;
        [SerializeField] float value;

        public LeadershipEnum GetLeadershipEnum()
        {
            return leadershipEnum;
        }

        public float GetValue()
        {
            return value;
        }
    }

    [System.Serializable]
    public class OrganizationEffect
    {
        [SerializeField] OrganisationEnum organisationEnum;
        [SerializeField] float value;

        public OrganisationEnum GetOrganisation()
        {
            return organisationEnum;
        }

        public float GetValue() { return value; }
    }


    [System.Serializable]
    public class SpecialRequirements
    {
        [SerializeField] LeadershipEffect[] leadershipEffects;
        [SerializeField] OrganizationEffect[] organizationEffects;
    }

}