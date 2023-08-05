using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leadership.Attribute;
using Leadership.Character;
using UnityEngine.UI;

namespace Leadership.Core
{
    public class LeadershipMechanic : MonoBehaviour
    {
        [SerializeField] LeadershipAttributesSO leadershipAttributes;

        [SerializeField] CharacterMechanic[] totalChacracter;
        [SerializeField] Text trustNumber;
        

        private float[] totalAllMemberRelation;

        private float calculatedTrusRate;


        private void Update() 
        {
            
            if(Input.GetKeyDown(KeyCode.Z))
            {
                CalculateAttributeRate(LeadershipEnum.Influence);
            }
            

            // trustNumber.text = leadershipAttributes.GetLeadershipAttributes(LeadershipEnum.Trust).ToString();
            if(totalChacracter == null) return;
            totalChacracter = FindObjectsOfType<CharacterMechanic>();
        }

        private void CalculateAttributeRate(LeadershipEnum category)
        {
                
                
                calculatedTrusRate = 0;
                for (int i = 0; i < totalChacracter.Length; i++)
                {
                    calculatedTrusRate += totalChacracter[i].GetStatsCharacter(category);
                }

                float averageTrust = calculatedTrusRate / totalChacracter.Length;
                print(averageTrust);

                leadershipAttributes.SetLeadershipAttributes(category, averageTrust);

        }


        //Change in the future
        public void AddEachMemberAttribute(LeadershipEnum category, float value)
        {

            for (int i = 0; i < totalChacracter.Length; i++)
            {
                totalChacracter[i].AddStatsCharacter(category, value);
                // print("bsia");
            }

        }
     
       

    

       public void SetMeetingDivision(DivisionEnum divisionEnum)
       {
            leadershipAttributes.SetJoinedMeetingDivision(divisionEnum);
       }

        
    }
}
