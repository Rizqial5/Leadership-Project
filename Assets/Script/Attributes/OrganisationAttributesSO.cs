using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Leadership.Attribute
{

    [CreateAssetMenu(menuName = "Leadership Project/OrganisationAttributesSO")]
    public class OrganisationAttributesSO : ScriptableObject
    {
        [SerializeField] OrganisationAttribute[] organisationAttributes;

        Dictionary<OrganisationEnum, float> organisationTableLookUp;

        public void SetOrgAttributes(OrganisationEnum orgEnum, float value)
        {
            BuildLookupTable();

            if(orgEnum == OrganisationEnum.Money)
            {
                organisationTableLookUp[orgEnum] += value;
            }

            if (organisationTableLookUp[orgEnum] == 100) return;

            organisationTableLookUp[orgEnum] += value; 
        }

        public float GetOrgAttributes(OrganisationEnum orgEnum)
        {
            BuildLookupTable();

            return organisationTableLookUp[orgEnum];
        }
        public void BuildLookupTable()
        {
            if(organisationTableLookUp != null) return;

            organisationTableLookUp = new Dictionary<OrganisationEnum,float>();

            foreach (OrganisationAttribute orgAttributes in organisationAttributes)
            {
                organisationTableLookUp[orgAttributes.Orgenum] = orgAttributes.value;
            }
        }

        
    }

    [System.Serializable]
    public class OrganisationAttribute
    {
        public OrganisationEnum Orgenum;
        public float value;
    }
}
