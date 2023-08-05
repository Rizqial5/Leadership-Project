using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace Leadership.Action
{
    [CreateAssetMenu(fileName = "Action Item", menuName = "Leadership Project/ActionSO", order = 0)]
    public class ActionSO : ScriptableObject 
    {
        [SerializeField] DivisionEnum divisionEnum;
        [SerializeField] string nameAction;
        [SerializeField] string descAction;
        [SerializeField] int actionRequirementDays;
        [SerializeField] float moneyRequirements;


        public string GetNameAction()
        {
            return nameAction;
        }

        public string GetDescAction()
        {
            return descAction;
        }

        //Effect umum dari action ini

        //Effect Khusus dari action ini berupa script sendiri
    }

}