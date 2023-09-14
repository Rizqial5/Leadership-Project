using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowImage : MonoBehaviour
{
    [SerializeField] GameObject objectToShow;

    public void ShowandClose()
    {

        if(objectToShow.activeInHierarchy == false) 
        {
            objectToShow.SetActive(true);
        }
        else if(objectToShow.activeInHierarchy == true)
        {
            objectToShow.SetActive(false);
        }
    }

   
}
