using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


namespace Leadership.Attribute
{
    public class AttributesMechanic : MonoBehaviour
    {
        [SerializeField] OrganisationAttributesSO orgAttributesSO;

        [Header("Attribute Limit")]
        [SerializeField] private int activitityRateLimit = 50;
        [SerializeField] private int performanceLimit = 30;
        [SerializeField] private int unityLimit = 30;


        void Update()
        {
            if (Input.GetKeyDown(KeyCode.M))
            {
                AddAttributes(OrganisationEnum.Money, 100);
                
            }
        }
        public void AddAttributes(OrganisationEnum organisationEnum,float value)
        {
            orgAttributesSO.SetOrgAttributes(organisationEnum,value);
        }

        public void AddMoney()
        {
            //addd rep percentage
            float repPercentage = orgAttributesSO.GetOrgAttributes(OrganisationEnum.Reputation) * 10 / 100;

            orgAttributesSO.SetOrgAttributes(OrganisationEnum.Money,10 + repPercentage);
        }

        public void AddAllAttributes(float value)
        {
            orgAttributesSO.SetOrgAttributes(OrganisationEnum.Activity,value);
            orgAttributesSO.SetOrgAttributes(OrganisationEnum.Money,value);
            orgAttributesSO.SetOrgAttributes(OrganisationEnum.Performance,value);
            orgAttributesSO.SetOrgAttributes(OrganisationEnum.Reputation,value);
            orgAttributesSO.SetOrgAttributes(OrganisationEnum.Unity ,value);
        }

        public bool CheckActivitiesRate()
        {
            if (orgAttributesSO.GetOrgAttributes(OrganisationEnum.Activity) > activitityRateLimit)
            {
                return true;
            }

            return false;
        }

        public bool CheckPerformance()
        {
            if(orgAttributesSO.GetOrgAttributes(OrganisationEnum.Performance) < performanceLimit)
            {
                return true;
            }

            return false;
        }

        public bool CheckUnity()
        {
            if(orgAttributesSO.GetOrgAttributes(OrganisationEnum.Unity) < unityLimit)
            {
                return true;    
            }

            return false;
        }

        public void UnityDecreasing()
        {
            AddAttributes(OrganisationEnum.Unity, -0.2f);
        }
    }
}
