using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Leadership.Action
{
    public class ActionPlay : MonoBehaviour
    {
        [SerializeField] DivisionEnum divisionEnum;


        public void ActionStart()
        {
            print("Action Play");
        }
    }
}
