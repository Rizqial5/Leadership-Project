using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leadership.Attribute;
using TMPro;
using UnityEngine.UI;
using UnityEngine.AI;

namespace Leadership.UI
{
    public class LevelLeadershipUI : MonoBehaviour
    {
        [SerializeField] LeadershipProgression leadershipProgression;
        [SerializeField] GameObject RequireBox;
        [SerializeField] GameObject approxRequire;
        [SerializeField] GameObject ChangeBox;
        [SerializeField] GameObject spawnDescList;
        [SerializeField] Sprite checkedImage;
        [SerializeField] Sprite uncheckedImage;

        private int percentage;
        private GameObject[] spawnedObjects;
        private bool isCheckedLevel2;
        private bool isCheckedLevel3;
        private bool isCheckedLevel4;
        private bool isCheckedLevel5;

        void Update()
        {
            
        }
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

        public void CheckIfEligible(int level)
        {
            if(spawnedObjects == null) return;
            foreach (GameObject item in spawnedObjects)
            {
                item.GetComponentInChildren<Image>().sprite = uncheckedImage;
            }
            
            if(level == 2)
            {
                if(isCheckedLevel2 == false) return;
                if(isCheckedLevel2 == true)
                {
                    foreach (GameObject item in spawnedObjects)
                    {
                        item.GetComponentInChildren<Image>().sprite = checkedImage;
                    }
                }
            }else if(level == 3)
            {
                if(isCheckedLevel3 == false) return;
                if(isCheckedLevel3 == true)
                {
                    foreach (GameObject item in spawnedObjects)
                    {
                        item.GetComponentInChildren<Image>().sprite = checkedImage;
                    }
                }
            }else if(level == 4)
            {
                if(isCheckedLevel4 == false) return;
                if(isCheckedLevel4 == true)
                {
                    foreach (GameObject item in spawnedObjects)
                    {
                        item.GetComponentInChildren<Image>().sprite = checkedImage;
                    }
                }
            }else if(level == 5)
            {
                if(isCheckedLevel5 == false) return;
                if(isCheckedLevel5 == true)
                {
                    foreach (GameObject item in spawnedObjects)
                    {
                        item.GetComponentInChildren<Image>().sprite = checkedImage;
                    }
                }
            }
            
        }

        public bool IsCheckedLevel2
        {
            set{isCheckedLevel2 = value;} get{return isCheckedLevel2;}
        }
        public bool IsCheckedLevel3
        {
            set{isCheckedLevel3 = value;} get{return isCheckedLevel3;}
        }
        public bool IsCheckedLevel4
        {
            set{isCheckedLevel4 = value;} get{return isCheckedLevel4;}
        }
        public bool IsCheckedLevel5
        {
            set{isCheckedLevel5 = value;} get{return isCheckedLevel5;}
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
