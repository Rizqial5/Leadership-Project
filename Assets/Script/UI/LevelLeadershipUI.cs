using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leadership.Attribute;
using TMPro;

namespace Leadership.UI
{
    public class LevelLeadershipUI : MonoBehaviour
    {
        [SerializeField] LeadershipProgression leadershipProgression;
        [SerializeField] GameObject RequireBox;
        [SerializeField] GameObject approxRequire;
        [SerializeField] GameObject ChangeBox;
        [SerializeField] GameObject spawnDescList;

        private int percentage;
        private GameObject[] spawnedObjects;

        public void ShowLevelRequirements(int level)
        {
            
            if(spawnedObjects !=null)
            {
                foreach (GameObject item in spawnedObjects)
                {
                    Destroy(item);
                }
            } 

            if(level == 2)
            {
                percentage = 50;
            }
            else if(level == 3)
            {
                percentage = 50;
            }
            else if(level == 4)
            {
                percentage = 50;
            }
            else if(level == 5)
            {
                percentage = 50;
            }

            approxRequire.GetComponent<TextMeshProUGUI>().text = "Total "+ percentage.ToString() + "% Characters are eligible for :";


            SpawnDescList("Relation : "+leadershipProgression.GetRequireStat(LeadershipEnum.Relation,level).ToString(), 0, .3f);
            SpawnDescList("Influence : "+leadershipProgression.GetRequireStat(LeadershipEnum.Influence,level).ToString(), 1, .3f);
            SpawnDescList("Morale : "+leadershipProgression.GetRequireStat(LeadershipEnum.Morale,level).ToString(), 2, .3f);
            SpawnDescList("Trust : "+leadershipProgression.GetRequireStat(LeadershipEnum.Trust,level).ToString(), 3, .3f);

            spawnedObjects = GameObject.FindGameObjectsWithTag("SpawnObject");

        }


        public void SpawnDescList( string name, int i, float beda)
        {
   
            var descList = Instantiate(spawnDescList,RequireBox.transform.position,RequireBox.transform.rotation,RequireBox.transform);
            
            descList.transform.position = new Vector3(descList.transform.position.x, (descList.transform.position.y + (i - 1) * beda));

            descList.GetComponentInChildren<TextMeshProUGUI>().text = name;

        }

        public void CloseUI()
        {
            gameObject.SetActive(false);
        }
    }
}
