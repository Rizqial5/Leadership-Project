using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leadership.UI;

namespace Leadership.Decisive
{
    public class DecisiveMechanic : MonoBehaviour
    {

        [SerializeField] DecisivieCaseSO[] decisiveCases;

        [SerializeField] DecisionEventUI decisionEventUI;
        void Awake()
        {
            
        }
        
        void Update()
        {
            print(decisionEventUI);
        }
        public void SpawnDecisiveCase(int leadershipLevelCase)
        {
            if(leadershipLevelCase == 1)
            {

            }
        }
    }

}