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


        public string GetDecisiveQuestion(int i)
        {
            return decisiveQuestion[i].GetQuestion();
        }

        public DecisiveAnswer[] GetDecisiveAnswer(int i)
        {
            return decisiveQuestion[i].GetDecisiveAnswers();
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

        public DecisiveAnswer[] GetDecisiveAnswers()
        {
            return decisiveAnswer;
        }
        
    }

    [System.Serializable]
    public class DecisiveAnswer
    {
        [TextArea(3,10)]
        [SerializeField] public string answerField;
        [SerializeField] public bool correctAnswer;

    }
}
