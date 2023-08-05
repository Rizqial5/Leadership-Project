using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpawnOutlinerTag : MonoBehaviour
{
    [SerializeField] public string divisionName;
    [SerializeField] TextMeshProUGUI timeText;
    

    public void DivisionName(string value)
    {
        divisionName = value;
    }

    public void ChangeToTransparent()
    {
        TextMeshProUGUI outlinerText = GetComponent<TextMeshProUGUI>();
    
        outlinerText.color = Color.clear;
        timeText.color = Color.clear;
    }

    public void ChangeToVisible()
    {
        TextMeshProUGUI outlinerText = GetComponent<TextMeshProUGUI>();

        outlinerText.color = Color.white;
        timeText.color = Color.white;
    }
}
 