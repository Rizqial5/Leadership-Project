using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leadership.UI;
using UnityEngine.Events;
using System.Dynamic;

namespace Leadership.Decisive
{
    public class DecisiveMechanic : MonoBehaviour
    {

        [SerializeField] DecisivieCaseSO[] decisiveCases;

        [SerializeField] DecisionEventUI decisionEventUI;

        private int totalCorrectAnswer;
        private int numberQuestion = 1;
        private bool isDecisiveCase;
        private int levelNow;

        public UnityEvent OnAfterChooseAnswer;
        public UnityEvent OnLevelUp;
        
        
        void Awake()
        {
            
        }
        
        void Update()
        {
            
        }


        public int LevelNow
        {
            set{levelNow = value;} get{return levelNow;}
        }
        public void SpawnDecisiveCase(int leadershipLevelCase, int decisiveQuestionNumber)
        {
            DecisivieCaseSO decisiveCase = decisiveCases[leadershipLevelCase];
            isDecisiveCase = true;

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
            if(isDecisiveCase == false) return;
            StartCoroutine(NextQuestion());
        }

        public IEnumerator NextQuestion()
        {
            yield return new WaitForSeconds(1f);

            ///edit untuk menentukan maks
            
            SpawnDecisiveCase(LevelNow - 1,numberQuestion); // perlu diedit
            numberQuestion++;

            print("Total pertanyaan : " + numberQuestion);
            
        }

        

        public void CountCorrectAnswer()
        {
            totalCorrectAnswer += 1;
            print("Total jawaban betul " + totalCorrectAnswer);
            
            if(totalCorrectAnswer == 3)
            {
                OnLevelUp.Invoke();
                totalCorrectAnswer = 0;
            }
            
            
        }


    }

}