using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Leadership.Attribute
{
    
    public class AttributesUI : MonoBehaviour
    {

        [SerializeField] TextMeshProUGUI goldText;
        [SerializeField] TextMeshProUGUI activityText;
        [SerializeField] TextMeshProUGUI perfText;
        [SerializeField] TextMeshProUGUI repText;
        [SerializeField] TextMeshProUGUI unityText;

        [SerializeField] OrganisationAttributesSO organisationAttributesSO;

        void Update()
        {
            goldText.text = organisationAttributesSO.GetOrgAttributes(OrganisationEnum.Money).ToString();
            activityText.text = organisationAttributesSO.GetOrgAttributes(OrganisationEnum.Activity).ToString();
            perfText.text = organisationAttributesSO.GetOrgAttributes(OrganisationEnum.Performance).ToString();
            repText.text = organisationAttributesSO.GetOrgAttributes(OrganisationEnum.Reputation).ToString();
            unityText.text = organisationAttributesSO.GetOrgAttributes(OrganisationEnum.Unity).ToString();
        }
        
    }
}