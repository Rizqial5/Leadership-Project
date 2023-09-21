using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leadership.Attribute;
using Leadership.Character;
using UnityEngine.UI;
using System.Linq;
using System;
using Leadership.Decisive;
using Leadership.UI;

namespace Leadership.Core
{
    public class LeadershipMechanic : MonoBehaviour
    {
        [SerializeField] LeadershipAttributesSO leadershipAttributes;
        

        [SerializeField] CharacterMechanic[] totalChacracter;
        [SerializeField] Text trustNumber;
        [SerializeField] int levelNow = 1;
        private DecisiveMechanic decisiveMechanic;
        [SerializeField] OurCharacterUI ourCharacterUI;
        [SerializeField] LevelLeadershipUI levelLeadershipUI;

        private float[] totalAllMemberRelation;
        private int totalEligibleCharLevelUpTwo;
        private int totalEligibleCharLevelUpThree;
        private int totalEligibleCharLevelUpFour;
        private int totalEligibleCharLevelUpFive;


        private float calculatedTrusRate;
        private float penalyTotal = -5;
        

        void Awake()
        {
            decisiveMechanic = GetComponent<DecisiveMechanic>();
            
              
        }
        private void Update() 
        {
            CanLevelUp(levelNow+1);
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
                // levelNow += 1;
                decisiveMechanic.OnLevelUp.Invoke();
            }
            if(Input.GetKeyDown(KeyCode.V))
            {
                

                if(CanLevelUp(levelNow+1) == true)

                decisiveMechanic.SpawnDecisiveCase(levelNow-1,0);

            }

            

            ourCharacterUI.ChangeLevelText(levelNow);




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

        public int CountCharEligibleLevelUp(int leadershipLevelCheck)
        {
            if(leadershipLevelCheck == 2)
            {
                totalEligibleCharLevelUpTwo = 0;
                for (int i = 0; i < totalChacracter.Length; i++)
                {
                    if(totalChacracter[i].IsLevelUpTwo != true) continue;
                    totalEligibleCharLevelUpTwo += 1; 
                
                }
                return totalEligibleCharLevelUpTwo;
            }else if(leadershipLevelCheck == 3)
            {
                totalEligibleCharLevelUpThree = 0;
                for (int i = 0; i < totalChacracter.Length; i++)
                {
                    if(totalChacracter[i].IsLevelUpThree != true) continue;
                    totalEligibleCharLevelUpThree += 1; 
                
                }
                return totalEligibleCharLevelUpThree;
            }else if(leadershipLevelCheck == 4)
            {
                totalEligibleCharLevelUpFour= 0;
                for (int i = 0; i < totalChacracter.Length; i++)
                {
                    if(totalChacracter[i].IsLevelUpFour != true) continue;
                    totalEligibleCharLevelUpFour += 1; 
                
                }
                return totalEligibleCharLevelUpFour;
            }else if(leadershipLevelCheck == 5)
            {
                totalEligibleCharLevelUpFive = 0;
                for (int i = 0; i < totalChacracter.Length; i++)
                {
                    if(totalChacracter[i].IsLevelUpFive != true) continue;
                    totalEligibleCharLevelUpFive += 1; 
                
                }
                return totalEligibleCharLevelUpFive;
            }  

            return 0;         
           
        }
       

        
       public void SetMeetingDivision(DivisionEnum divisionEnum)
       {
            leadershipAttributes.SetJoinedMeetingDivision(divisionEnum);
       }

       public int GetLevelLeadershipPlayer()
       {
            return levelNow;
       }

       public LevelLeadershipUI GetLevelLeadershipUI()
       {
            return levelLeadershipUI;
       }

       public bool CanLevelUp(int levelUp)
       {
            
            if(levelUp == 2)
            {
                if(CountCharEligibleLevelUp(levelUp) != totalChacracter.Length)
                {
                    levelLeadershipUI.IsCheckedLevel2 = false;
                    return false;
                    
                }
                
                levelLeadershipUI.IsCheckedLevel2 = true;
                return true;
            }else if(levelUp == 3)
            {
                if(CountCharEligibleLevelUp(levelUp) != totalChacracter.Length)
                {
                    levelLeadershipUI.IsCheckedLevel3 = false;
                    return false;
                    
                }
                
                levelLeadershipUI.IsCheckedLevel3 = true;
                return true;
                
            }else if(levelUp == 4)
            {
                if(CountCharEligibleLevelUp(levelUp) != totalChacracter.Length)
                {
                    levelLeadershipUI.IsCheckedLevel4 = false;
                    return false;
                    
                }
                
                levelLeadershipUI.IsCheckedLevel4 = true;
                return true;

            }else if(levelUp == 5)
            {
                if(CountCharEligibleLevelUp(levelUp) != totalChacracter.Length)
                {
                    levelLeadershipUI.IsCheckedLevel5 = false;
                    return false;
                    
                }
                
                levelLeadershipUI.IsCheckedLevel5 = true;
                return true;
            }

            //Penambahan untuk level selanjutnya janlup

            
            return false;
       }

       public void LevelUp()
       {
            levelNow++;
       }

       public void SetPenaltyTotal()
       {

            if(levelNow == 1)
            {
                penalyTotal = -5;

            }else if(levelNow == 2)
            {
                penalyTotal = -10;

            }else if(levelNow == 3)
            {
                penalyTotal = -20;
                
            }else if(levelNow == 4)
            {
                penalyTotal = -30;
                
            }else if(levelNow == 5)
            {
                penalyTotal = -50;
                
            }
       }

       public void PenaltyAttribute()
       {
            print("Mendapatkan penalty " + penalyTotal);
            AddAllMemberAttribute(penalyTotal);
       }

       public void DecisiveCaseStart()
       {
            decisiveMechanic.LevelNow = levelNow;
            decisiveMechanic.SpawnDecisiveCase(levelNow-1,0);
       }

       

        
    }
}
