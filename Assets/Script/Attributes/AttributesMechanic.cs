using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


namespace Leadership.Attribute
{
    public class AttributesMechanic : MonoBehaviour
    {
        [SerializeField] OrganisationAttributesSO orgAttributesSO;

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
            orgAttributesSO.SetOrgAttributes(OrganisationEnum.Money,10);
        }

        public void AddAllAttributes(float value)
        {
            orgAttributesSO.SetOrgAttributes(OrganisationEnum.Activity,value);
            orgAttributesSO.SetOrgAttributes(OrganisationEnum.Money,value);
            orgAttributesSO.SetOrgAttributes(OrganisationEnum.Performance,value);
            orgAttributesSO.SetOrgAttributes(OrganisationEnum.Reputation,value);
            orgAttributesSO.SetOrgAttributes(OrganisationEnum.Unity ,value);
        }
    }
}
