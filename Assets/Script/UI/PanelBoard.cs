using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Leadership.UI
{
    public class PanelBoard : MonoBehaviour
    {
        [SerializeField] public TextMeshProUGUI windowTitle;


        [Header("Spawn Item")]
        [SerializeField] GameObject objectSpawnItem;
        [SerializeField] Transform parentTransform;
        [SerializeField] Transform spawnLoc;


        
        


        public void SpawnObjectList(string[] objectItem, string[] descItem, string subTitleText)
        {
            for (int i = 0; i < objectItem.Length; i++)
            {
                var objectSpawn = Instantiate(objectSpawnItem, parentTransform);

                objectSpawn.transform.position = new Vector3(spawnLoc.position.x, (spawnLoc.position.y + (i - 1) * -0.8f));

                objectSpawn.GetComponentInChildren<TextMeshProUGUI>().text = objectItem[i];

                

                objectSpawn.GetComponent<ObjectItem>().SetDescItemText(descItem[i]);
                objectSpawn.GetComponent<ObjectItem>().SetSubtitleText(subTitleText);


            }
        }

        public void CloseFunction()
        {
            Destroy(this.gameObject);
        }

        


    }
}
