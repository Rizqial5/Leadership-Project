using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Leadership.UI
{
    public class MessageScript : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI headerText;

   
        [SerializeField] TextMeshProUGUI descText;

        public void ChangeText(string headerInText, string descInText)
        {
            headerText.text = headerInText;
            descText.text = descInText;
        }
    }

}