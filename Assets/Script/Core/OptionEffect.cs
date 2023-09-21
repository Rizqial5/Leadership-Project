using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leadership.Management;
using Leadership.Attribute;

namespace Leadership.Core
{
    public class OptionEffect : MonoBehaviour
    {

        [SerializeField] bool isAdded;
        [SerializeField] DivisionEnum divisionEnum;
        Dictionary<LeadershipEnum,float> leadershipEffectOption;
        Dictionary<OrganisationEnum, float> organisationEffectOption;

        

        public void SetLeadershipEffect(CaseEffect[] caseEffect)
        {
            BUildLookupLeadership();

            for (int i = 0; i < caseEffect.Length; i++)
            {
                leadershipEffectOption[caseEffect[i].leadershipEnum] = caseEffect[i].effectAttribute;
                isAdded = true;
            }
        }

        public void SetOrgEffect(CaseOrgEffect[] caseorgEffect)
        {
            BUildLookupOrg();

            for (int i = 0; i < caseorgEffect.Length; i++)
            {
                organisationEffectOption[caseorgEffect[i].organisationEnum] = caseorgEffect[i].effectAttribute;
                isAdded = true;
            }
        }

        public void SetDivisionEffect(DivisionEnum setDivisionEnum)
        {
            divisionEnum = setDivisionEnum;
        }


        public void BUildLookupLeadership()
        {
            if(leadershipEffectOption != null) return;

            leadershipEffectOption = new Dictionary<LeadershipEnum, float>();
        }

        public void BUildLookupOrg()
        {
            if(organisationEffectOption != null) return;

            organisationEffectOption = new Dictionary<OrganisationEnum, float>();
        }

        public void EffectActive()
        {
            BUildLookupLeadership();
            BUildLookupOrg();

            LeadershipMechanic leadershipMechanic = FindObjectOfType<LeadershipMechanic>();
            AttributesMechanic attributesMechanic = FindObjectOfType<AttributesMechanic>();

            foreach (var item in leadershipEffectOption)
            {
                //Changed in the future just test
                
                
                leadershipMechanic.AddEachMemberAttribute(divisionEnum,item.Key,item.Value);

                //Notif.Invoke() 
                // print(item.Key + " Effect has been activated total " + item.Value);
            }

            foreach (var item in organisationEffectOption)
            {
                
                attributesMechanic.AddAttributes(item.Key, item.Value);

                print("Berhasil ditambahkan");

            }
        }
    
    }
}
