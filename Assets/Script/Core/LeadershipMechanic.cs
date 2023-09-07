using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leadership.Attribute;
using Leadership.Character;
using UnityEngine.UI;
using System.Linq;
using System;

namespace Leadership.Core
{
    public class LeadershipMechanic : MonoBehaviour
    {
        [SerializeField] LeadershipAttributesSO leadershipAttributes;
        

        [SerializeField] CharacterMechanic[] totalChacracter;
        [SerializeField] Text trustNumber;
        [SerializeField] int levelNow;

        private float[] totalAllMemberRelation;
        private int totalEligibleCharLevelUpTwo;
        private int totalEligibleCharLevelUpThree;
        private int totalEligibleCharLevelUpFour;
        private int totalEligibleCharLevelUpFive;

        private float calculatedTrusRate;

        
        private void Update() 
        {
            //Testing-----------
            if(Input.GetKeyDown(KeyCode.Z))
            {
                AddAllMemberAttribute(50);
            }
            if(Input.GetKeyDown(KeyCode.P))
            {
                AddSpesificMember("Character", 100);
            }
            if(Input.GetKeyDown(KeyCode.M))
            {
                CountCharEligibleLevelUp(2);
            }
            

            
            // trustNumber.text = leadershipAttributes.GetLeadershipAttributes(LeadershipEnum.Trust).ToString();
            if(totalChacracter == null) return;
            totalChacracter = FindObjectsOfType<CharacterMechanic>();

            
            

            if(totalEligibleCharLevelUpTwo == totalChacracter.Length)
            {
                print("Bisa naik level");
            }
            
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

        public void AddEachMemberAttribute(DivisionEnum divisionEnum,LeadershipEnum category, float value)
        {

            for (int i = 0; i < totalChacracter.Length; i++)
            {
                if(totalChacracter[i].GetDivisionCharacter() != divisionEnum) continue;
                totalChacracter[i].AddStatsCharacter(category, value);
                // print("bsia");
            }

        }

        public void AddSpesificMember(string name, float value)
        {
            for (int i = 0; i < totalChacracter.Length; i++)
            {
                if(totalChacracter[i].name == name)
                {
                    totalChacracter[i].AddAllStatsChar(value);
                }
            }
        }

        //Testing Function----------------------------------------------
        public void AddAllMemberAttribute(float value)
        {

            for (int i = 0; i < totalChacracter.Length; i++)
            {
                totalChacracter[i].AddStatsCharacter(LeadershipEnum.Relation, value);
                totalChacracter[i].AddStatsCharacter(LeadershipEnum.Influence, value);
                totalChacracter[i].AddStatsCharacter(LeadershipEnum.Trust, value);
                totalChacracter[i].AddStatsCharacter(LeadershipEnum.Morale, value);
                // print("bsia");
            }

        }

        public void CountCharEligibleLevelUp(int leadershipLevelCheck)
        {
            if(leadershipLevelCheck == 2)
            {
                totalEligibleCharLevelUpTwo = 0;
                for (int i = 0; i < totalChacracter.Length; i++)
                {
                    if(totalChacracter[i].IsLevelUpTwo != true) continue;
                    totalEligibleCharLevelUpTwo += 1; 
                
                }
                print(totalEligibleCharLevelUpTwo);
            }else if(leadershipLevelCheck == 3)
            {
                totalEligibleCharLevelUpThree = 0;
                for (int i = 0; i < totalChacracter.Length; i++)
                {
                    if(totalChacracter[i].IsLevelUpThree != true) continue;
                    totalEligibleCharLevelUpThree += 1; 
                
                }
                print(totalEligibleCharLevelUpThree);
            }else if(leadershipLevelCheck == 4)
            {
                totalEligibleCharLevelUpFour= 0;
                for (int i = 0; i < totalChacracter.Length; i++)
                {
                    if(totalChacracter[i].IsLevelUpFour != true) continue;
                    totalEligibleCharLevelUpFour += 1; 
                
                }
                print(totalEligibleCharLevelUpFour);
            }else if(leadershipLevelCheck == 5)
            {
                totalEligibleCharLevelUpFive = 0;
                for (int i = 0; i < totalChacracter.Length; i++)
                {
                    if(totalChacracter[i].IsLevelUpFive != true) continue;
                    totalEligibleCharLevelUpFive += 1; 
                
                }
                print(totalEligibleCharLevelUpFive);
            }           
           
        }
       

        
       public void SetMeetingDivision(DivisionEnum divisionEnum)
       {
            leadershipAttributes.SetJoinedMeetingDivision(divisionEnum);
       }

        
    }
}
