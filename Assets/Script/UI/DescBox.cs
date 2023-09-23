using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Leadership.UI
{
    public class DescBox : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI ReqDesc;
        [SerializeField] Transform effectDesc;

        [SerializeField] GameObject effectList;

        [SerializeField] private GameObject[] gameObjects;

        private int i;
        public void ChangeReqAction(string value)
        {
            ReqDesc.text = value;
        }

        public void ChangeEffectAction(Dictionary<string, float> value)
        {
            if (gameObjects != null)
            {
                foreach (var obj in gameObjects) { Destroy(obj); }
            }
            foreach (var item in value)
            {
                i += 1;
                GameObject listEffect = Instantiate(effectList, effectDesc.position, effectDesc.rotation, effectDesc);

                gameObjects[i] = listEffect;
                listEffect.transform.position = new Vector3(listEffect.transform.position.x, (listEffect.transform.position.y + (i - 1) * -0.3f)); ;
                listEffect.GetComponent<TextMeshProUGUI>().text = item.Key + " : " + item.Value;

                
            }

            i = 0;
        }

        public void DestroyObject()
        {
            if (gameObjects == null) return;
            for (int j = 0; j < gameObjects.Length; j++)
            {
                Destroy(gameObjects[j]);
            }
        }
    }
}