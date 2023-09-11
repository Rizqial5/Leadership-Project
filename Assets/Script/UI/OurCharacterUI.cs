using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.PackageManager;
using UnityEngine;


namespace Leadership.UI
{
    public class OurCharacterUI : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI LeadershipNow;

        private int levelLeadNow;

        void Update()
        {
            LeadershipNow.text = levelLeadNow.ToString();
        }

        public int ChangeLevelText( int levelNow)
        {
            return levelLeadNow = levelNow;
        }
        
    }
}
