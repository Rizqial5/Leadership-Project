using System.Collections;
using System.Collections.Generic;
using Leadership.UI;
using UnityEngine;

public class MenuSetting : MonoBehaviour
{
    [SerializeField] GameObject[] items;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ExitMenu()
    {
        foreach (GameObject item in items )
        {
            item.SetActive(false);
        }
    }

    public void CloseInteractionRoom()
    {
        if(!FindObjectOfType<RoomDesc>().gameObject.activeInHierarchy) return;

        FindObjectOfType<RoomDesc>().gameObject.SetActive(false);
    }

    public void SetActiveObject(bool value)
    {
        foreach (GameObject item in items )
        {
            item.SetActive(value);
        }
    }

    public bool CheckActiveObject()
    {
        foreach (GameObject item in items )
        {
            return item.activeInHierarchy;
        }

        return false;
    }
}
