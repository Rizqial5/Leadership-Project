using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Leadership.UI
{
    public class SpawnActionTag : MonoBehaviour 
    {
        
        private string _descText;
        private string _reqText;
        private Dictionary<string, float> _effectText;
        public string ChangeDesc(string value)
        {
           return _descText = value;
        }

        public string ChangeReq(string value)
        {
            return _reqText = value;
        }

        public Dictionary<string , float> ChangeEffect(Dictionary<string, float> value)
        {
            return _effectText = value;
        }

        public void ChangeDescInGame()
        {

            if(_descText == null) return;
            DescBox descBox = FindObjectOfType<DescBox>();

            descBox.GetComponentInChildren<TextMeshProUGUI>().text = _descText;
            descBox.ChangeReqAction(_reqText);
            descBox.ChangeEffectAction(_effectText);

            //Change Desc Effect
            
        }




    
    }
}