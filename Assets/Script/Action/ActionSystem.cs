using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;

namespace Leadership.Action
{


    public class ActionSystem : MonoBehaviour 
    {
        [SerializeField] ActionSO[] actionItem;
        [SerializeField] DivisionEnum divisionEnum;
        
        
        public ActionSO[] GetActionSO()
        {
            return actionItem;
        }

        internal DivisionEnum GetDivisionEnum()
        {
            return divisionEnum;
        }
    }
}