using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Leadership.UI
{
    public class MessageScript : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI headerText;

   
        [SerializeField] TextMeshProUGUI descText;

        [SerializeField] Button buttonGameObject;

        public void ChangeText(string headerInText, string descInText)
        {
            headerText.text = headerInText;
            descText.text = descInText;
        }

        public void SetActiveButton(bool setActive)
        {
           buttonGameObject.gameObject.SetActive(setActive);
        }

        public void CloseButton()
        {
            Destroy(gameObject);
        }
    }

}