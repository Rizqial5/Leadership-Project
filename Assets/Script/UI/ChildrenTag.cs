using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChildrenTag : MonoBehaviour
{

    private string textEffect;
    [SerializeField] private int _startMeetingTime;

    
    public string ChangeTextEffect(string value)
    {
        return GetComponent<TextMeshProUGUI>().text = value;
    }

    public int startMeetingTime
    {
        get{return _startMeetingTime;} set{_startMeetingTime = value;}
    }
}
