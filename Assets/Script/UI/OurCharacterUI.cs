using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Leadership.Core;


namespace Leadership.UI
{
    public class OurCharacterUI : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI LeadershipNow;
        [SerializeField] TextMeshProUGUI periodTime;

        private int levelLeadNow;
        private GameManager gameManager;

        private void Awake()
        {
            gameManager = FindObjectOfType<GameManager>();
        }

        void Update()
        {
            LeadershipNow.text = levelLeadNow.ToString();
            periodTime.text = gameManager.GetTotalTimeLeft().ToString() +" weeks left";
        }

        public int ChangeLevelText( int levelNow)
        {
            return levelLeadNow = levelNow;
        }
        
    }
}
