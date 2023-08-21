using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leadership.Attribute;
using UnityEngine.UI;
using TMPro;

namespace Leadership.UI
{
    public class OrgAtributesUI : MonoBehaviour
    {
        [SerializeField] OrganisationAttributesSO organisationAttributesSO;

        [SerializeField] TextMeshProUGUI goldTextNumber;
        [SerializeField] TextMeshProUGUI activityTextNumber;
        [SerializeField] TextMeshProUGUI performanceTextNumber;
        [SerializeField] TextMeshProUGUI reputationTextNumber;
        [SerializeField] TextMeshProUGUI unityTextNumber;

        void Update()
        {
            goldTextNumber.text = organisationAttributesSO.GetOrgAttributes(OrganisationEnum.Money).ToString();
            activityTextNumber.text = organisationAttributesSO.GetOrgAttributes(OrganisationEnum.Activity).ToString();
            performanceTextNumber.text = organisationAttributesSO.GetOrgAttributes(OrganisationEnum.Performance).ToString();
            reputationTextNumber.text = organisationAttributesSO.GetOrgAttributes(OrganisationEnum.Reputation).ToString();
            unityTextNumber.text = organisationAttributesSO.GetOrgAttributes(OrganisationEnum.Unity).ToString();
        }
        


    }
}
