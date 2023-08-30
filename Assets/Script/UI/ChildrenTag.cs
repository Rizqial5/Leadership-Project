using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChildrenTag : MonoBehaviour
{

    private string textEffect;
    [SerializeField] private int _startMeetingDay;

    
    public string ChangeTextEffect(string value)
    {
        return GetComponent<TextMeshProUGUI>().text = value;
    }

    public int startMeetingDay
    {
        get{return _startMeetingDay;} set{_startMeetingDay = value;}
    }
}
