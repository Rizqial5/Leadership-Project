using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

namespace Leadership.Core
{
    public class GameEnd : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI leadershipText;
        
        
        public void SetLeadershipText(string lvlLeadership)
        {
            leadershipText.text = lvlLeadership;
        }

        public void EndGame()
        {
            
            SceneManager.LoadScene("Menu Scene");
        }
    }
}
