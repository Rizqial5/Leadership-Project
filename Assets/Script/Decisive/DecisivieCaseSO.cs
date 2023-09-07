using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Leadership.Decisive
{
   
    
    [CreateAssetMenu(menuName = "Leadership Project/DecisivieCaseSO")]
    public class DecisivieCaseSO : ScriptableObject
    {
        [SerializeField] int levelLeadershipEvent;
        [SerializeField] DecisiveQuestion[] decisiveQuestion;


        public void GetDecisiveQuestion(int i)
        {
            decisiveQuestion[i].GetQuestion();
        }
    }

    [System.Serializable]
    public class DecisiveQuestion
    {
        [TextArea(3,10)]
        [SerializeField] string questionField;
        [SerializeField] DecisiveAnswer[] decisiveAnswer;

        public string GetQuestion()
        {
            return questionField;
        }
        
    }

    [System.Serializable]
    public class DecisiveAnswer
    {
        [TextArea(3,10)]
        [SerializeField] string answerField;
        [SerializeField] bool correctAnswer;

    }
}
