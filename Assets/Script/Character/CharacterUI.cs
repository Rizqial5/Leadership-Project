using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Leadership.Character
{
    public class CharacterUI : MonoBehaviour
    {
        [SerializeField] public TextMeshProUGUI nameCharacter;
        [SerializeField] public TextMeshProUGUI positionCharacter;
        [SerializeField] public TextMeshProUGUI divisionCharacter;

        [SerializeField] public TextMeshProUGUI trustAttribute;
        [SerializeField] public TextMeshProUGUI relationAttribute;
        [SerializeField] public TextMeshProUGUI influenceAttribute;
        [SerializeField] public TextMeshProUGUI moraleAttribute;

        [SerializeField] public TextMeshProUGUI leadershipLevels;

        [SerializeField] public TextMeshProUGUI statusState;

        [SerializeField] public Image characterPicture;

        public void CloseUI()
        {
            gameObject.SetActive(false);
        }


    }
}
