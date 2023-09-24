using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Leadership.UI
{
    public class PanelStoryEvent : MonoBehaviour
    {
        [SerializeField] private GameObject nameEvent;
        [SerializeField] private GameObject imageEvent;

        [Header("Content Story")]
        [SerializeField] private GameObject descEvent;
        [SerializeField] private OptionsAnswer[] listOptions;

        [SerializeField] private float accumulationEffect;

        public void SetNameEvent( string name)
        {
            nameEvent.GetComponent<TextMeshProUGUI>().text = name;
        }
        public void SetImageEvent(Sprite image)
        {
           imageEvent.GetComponent<Image>().sprite = image;
        }
        public void SetDescEvent(string desc)
        {
            descEvent.GetComponent<TextMeshProUGUI>().text = desc;
        }
        public void SetButtonEvent(string name,float effect, int indexButton)
        {
            listOptions[indexButton].SetButtonName(name);
            listOptions[indexButton].SetEffectBUtton(effect);
            //Menyusul
        }

        public Button SetButtonFunction(int indexButton)
        {
            return listOptions[indexButton].GetButton();
        }

        public void ActiveButton(int indexButon)
        {
            print("Mendapatkan nilai up " + listOptions[indexButon].GetEffectBUtton());

            accumulationEffect += listOptions[indexButon].GetEffectBUtton();
        }

        public float GetAccumulation()
        {
            return accumulationEffect;
        }
    }

    [System.Serializable]
    public class OptionsAnswer
    {
        [SerializeField] Button buttonAns;
        [SerializeField] float effectAns;

        public void SetButtonName(string name) { buttonAns.GetComponentInChildren<TextMeshProUGUI>().text = name; }
        public void SetEffectBUtton(float effect) { effectAns = effect; }

        public string GetButtonName() { return buttonAns.GetComponentInChildren<TextMeshProUGUI>().text; }
        public float GetEffectBUtton() {  return effectAns; }

        public Button GetButton() { return buttonAns; }
        
    }
}
