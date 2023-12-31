using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Leadership.Decisive
{
    public class DecAnswerButtonBehave : MonoBehaviour
    {
        [SerializeField] public bool correctAnswer;

        

        public void CheckCorrectAnswer()
        {
            if(correctAnswer == true)
            {
                FindObjectOfType<DecisiveMechanic>().CountCorrectAnswer();
            }else if(correctAnswer == false)
            {
                FindObjectOfType<DecisiveMechanic>().CountWrongAnswer();
            }

            FindObjectOfType<DecisiveMechanic>().OnAfterChooseAnswer.Invoke();
        }

        
    }
}
