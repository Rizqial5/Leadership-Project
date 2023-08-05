using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Leadership.UI
{
    public class SpawnObject : MonoBehaviour
    {
        
        public void SetStatusLeaderTag()
        {
            LeaderTag leaderTag = FindObjectOfType<LeaderTag>();

            leaderTag.gameObject.SetActive(false);
            
        }

        public void SetActiveObject()
        {
            GetComponentInChildren<Button>().enabled = false;
        }

        
    }
}
