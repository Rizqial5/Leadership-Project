using Leadership.Attribute;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Leadership.Interact
{
    [CreateAssetMenu(fileName = "InteractSO", menuName = "Leadership Project/InteractSO", order = 0)]
    public class InteractSO : ScriptableObject
    {
        [TextArea(3,10)]
        [SerializeField] private string storyText;

        [SerializeField] DecisionOption[] decisionOptions;
    }

    [System.Serializable]
    public class DecisionOption
    {
        [TextArea(3, 10)]
        [SerializeField] private string optionText;
        [SerializeField] private LeadershipEffect[] leadershipEffect;
        
        
    }


    [System.Serializable]
    internal class LeadershipEffect
    {
        [SerializeField] LeadershipEnum leadershipEnum;
        [SerializeField] private float value;
    }
}
