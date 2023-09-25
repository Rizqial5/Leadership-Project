using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Leadership.UI
{
    public class ObjectDesc : MonoBehaviour
    {
        [SerializeField] GameObject subtitleText;
        [SerializeField] GameObject descText;

        public void SetDescText(string text)
        {
            descText.GetComponent<TextMeshProUGUI>().text = text;
        }
        public void SetSubtitle(string text)
        {
            subtitleText.GetComponent<TextMeshProUGUI>().text = text;
        }
    }
}
