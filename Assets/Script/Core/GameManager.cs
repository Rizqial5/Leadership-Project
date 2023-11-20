using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace Leadership.Core
{
    public class GameManager : MonoBehaviour
    {

        [SerializeField] TurnSystem turnSystem;
        [SerializeField] LeadershipMechanic leadershipMechanic;

        [Header("Game end properties")]
        [SerializeField] GameObject gameEndObject;
        [SerializeField] Transform parentGameEnd;
        [SerializeField] int timeLimit = 20;

        private bool isSpawned = false;
        
        public  bool PlayState()
        {
            return turnSystem.IsPlay();
        }
        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            
            if(Input.GetKeyDown(KeyCode.Escape)) { SceneManager.LoadScene("Menu Scene"); }

            if(turnSystem.TotalWeek == timeLimit)
            {
                if (isSpawned == true) return; 
                GameObject gameEnd = Instantiate(gameEndObject, parentGameEnd);

                gameEnd.GetComponent<GameEnd>().SetLeadershipText(leadershipMechanic.GetLevelNow().ToString());

                isSpawned = true;
            }

            //if(Input.GetKeyDown(KeyCode.T)) { turnSystem.TotalWeek = 18; }
            
        }

        public int GetTimeLimit() { return timeLimit; }
        public int GetTotalTimeLeft() { return timeLimit - turnSystem.TotalWeek; }
    }

}
