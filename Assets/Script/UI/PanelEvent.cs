using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Leadership.UI
{
    public class PanelEvent : MonoBehaviour
    {
        [SerializeField] private GameObject nameEvent;
        [SerializeField] private GameObject imageEvent;


        public void SetNameEvent(string name)
        {
            nameEvent.GetComponent<TextMeshProUGUI>().text = name;
        }

        public void SetImageEvent(Sprite image)
        {
            imageEvent.GetComponent<Image>().sprite = image;
        }
    }
}
