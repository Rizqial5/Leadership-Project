using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Leadership.UI
{
    public class ObjectItem : MonoBehaviour
    {
        [TextArea(3, 10)]
        [SerializeField] private string descItemText;

        
        [SerializeField] private string subtitleText;

        private ObjectDesc panelDesc;

        private void Awake()
        {
            panelDesc = FindObjectOfType<ObjectDesc>();
        }
        public void SetDescItemText(string text)
        {
            descItemText = text;
        }

        public void SetSubtitleText(string text)
        {
            subtitleText = text;
        }

        public void SetDescInGame()
        {
            panelDesc.SetDescText(descItemText);
            panelDesc.SetSubtitle(subtitleText);
              
        }

        
    }
}
