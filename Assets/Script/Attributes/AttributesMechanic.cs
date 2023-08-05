using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Leadership.Attribute
{
    public class AttributesMechanic : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI moneyText;
        [SerializeField] AttributesSO attributesSO;

        
        public void AddAttributes()
        {
            attributesSO.Money += 10;
            moneyText.text = attributesSO.Money.ToString();
        }
    }
}
