using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leadership.UI;
using UnityEngine.Events;

namespace Leadership.Decisive
{
    public class DecisiveMechanic : MonoBehaviour
    {

        [SerializeField] DecisivieCaseSO[] decisiveCases;

        [SerializeField] DecisionEventUI decisionEventUI;

        private int totalCorrectAnswer;
        private int numberQuestion = 1;

        public UnityEvent OnAfterChooseAnswer;
        
        void Awake()
        {
            
        }
        
        void Update()
        {
            if(Input.GetKeyDown(KeyCode.V))
            {
                SpawnDecisiveCase(0,0);
            }
        }
        public void SpawnDecisiveCase(int leadershipLevelCase, int decisiveQuestionNumber)
        {
            DecisivieCaseSO decisiveCase = decisiveCases[leadershipLevelCase];

            if(numberQuestion > 2)
            {
                numberQuestion = 0;
                return;
            } 

            decisionEventUI.gameObject.SetActive(true);

            decisionEventUI.SetHeaderText(decisiveCase.name);
            decisionEventUI.SetStoryText(decisiveCase.GetDecisiveQuestion(decisiveQuestionNumber));

            print(decisiveCase.GetDecisiveAnswer(decisiveQuestionNumber).Length);

            for (int i = 0; i < decisiveCase.GetDecisiveAnswer(decisiveQuestionNumber).Length; i++)
            {
                
                decisionEventUI.SpawnButton(decisiveCase.GetDecisiveAnswer(decisiveQuestionNumber)[i].answerField, i, .8f,decisiveCase.GetDecisiveAnswer(decisiveQuestionNumber)[i].correctAnswer);

                
            }
            
        }


        public void NextButton()
        {
            StartCoroutine(NextQuestion());
        }

        public IEnumerator NextQuestion()
        {
            yield return new WaitForSeconds(1f);

            ///edit untuk menentukan maks
            
            SpawnDecisiveCase(0,numberQuestion);
            numberQuestion++;
            
        }

        

        public int CountCorrectAnswer()
        {
            totalCorrectAnswer += 1;
            print(totalCorrectAnswer);
            return totalCorrectAnswer;
            
        }


    }

}