using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Leadership.Core
{
    [CreateAssetMenu(fileName = "Insight Item", menuName = "Leadership Project/InsightSO", order = 0)]
    public class InsightSO : ScriptableObject
    {
        [TextArea(3, 10)]
        [SerializeField] string insightText;

        public string InsightText {  get { return insightText; } }
    }
}