using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leadership.UI;

namespace Leadership.Core
{
    public class InsightSystem : MonoBehaviour
    {
        [SerializeField] InsightContainer[] insightContainers;
        [SerializeField] GameObject insightUI;
        [SerializeField] Transform parentInsightUI;

       private GameObject insightSpawn;


        public IEnumerator SpawnInsight(int levelLeadership)
        {
            
            foreach (var item in insightContainers)
            {
                if(item.LevelLeadership == levelLeadership)
                {
                    int randomNumber = Random.Range(0, item.GetInsightSO().Length);

                    insightSpawn = Instantiate(insightUI, parentInsightUI);

                    insightSpawn.GetComponent<MessageScript>().ChangeText("Insight Leadership LV. " + item.LevelLeadership, item.GetInsightSO()[randomNumber].InsightText);

                }
            }

            yield return new WaitForSeconds(2f);

            StartCoroutine(DestroyGameObject(insightSpawn));



            
        }

        public IEnumerator DestroyGameObject(GameObject item)
        {
            yield return new WaitForSeconds(2f);
        }
    }

    [System.Serializable]

    public class InsightContainer
    {
        [SerializeField] int levelLeadership;
        [SerializeField] InsightSO[] insightItems;

        public int LevelLeadership{ get { return levelLeadership; } }
        public InsightSO[] GetInsightSO() {  return insightItems; }
    }
}
