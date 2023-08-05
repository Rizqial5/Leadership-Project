using TMPro;
using UnityEngine;

namespace Leadership.UI
{
    public class SpawnActionTag : MonoBehaviour 
    {
        
        private string _descText;
        public string ChangeDesc(string value)
        {
           return _descText = value;
        }

        public void ChangeDescInGame()
        {

            if(_descText == null) return;
            DescBox descBox = FindObjectOfType<DescBox>();

            descBox.GetComponentInChildren<TextMeshProUGUI>().text = _descText;
            
            //Change Desc Effect
            // descBox.GetComponentInChildren<ChildrenTag>().ChangeTextEffect("asu");
        }




    
    }
}