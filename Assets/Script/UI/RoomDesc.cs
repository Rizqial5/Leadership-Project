using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;



namespace Leadership.UI
{
    public class RoomDesc : MonoBehaviour
    {
        [SerializeField] Text roomTitle;
        [SerializeField] TextMeshProUGUI statustext;
        [SerializeField] Button statusButton;
        
        
        

        public void roomTitleText(string title )
        {
            roomTitle.text = title;
        }

        public string StatusText
        {
            get{return statustext.text;} set{statustext.text = value;} 
        }

        
    }
}

