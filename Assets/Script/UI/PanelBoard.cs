using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Leadership.UI
{
    public class PanelBoard : MonoBehaviour
    {
        [SerializeField] public TextMeshProUGUI windowTitle;


        [Header("Spawn Item")]
        [SerializeField] GameObject objectSpawnItem;
        [SerializeField] Transform parentTransform;

        [Header("Desc Box")]
        [SerializeField] TextMeshProUGUI descText;


        public void SpawnObjectList(string[] objectItem)
        {
            for (int i = 0; i < objectItem.Length; i++)
            {
                var objectSpawn = Instantiate(objectSpawnItem, parentTransform);

                objectSpawn.transform.position = new Vector3(parentTransform.position.x, (parentTransform.position.y + (i - 1) * -0.8f));

                objectSpawn.GetComponentInChildren<TextMeshProUGUI>().text = objectItem[i];
            }
        }


    }
}
