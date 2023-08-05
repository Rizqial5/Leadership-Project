using System.Collections;
using System.Collections.Generic;
using UnityEngine;


 
namespace Leadership.Schedule
{
    [CreateAssetMenu(fileName = "SOMonth", menuName = "Leadership Project/SOMonth", order = 0)]
    public class SOMonth : ScriptableObject 
    {
        [SerializeField] MonthEnum monthEnum;
        [SerializeField] int totalDate;
    }

}