using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Leadership.Character
{
    public class CharacterInteraction : MonoBehaviour
    {
        [SerializeField] CharacterUI characterUI;
        [SerializeField] CharacterAttributesSO characterAttributesSO;
        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        private void OnMouseDown() {

            if(EventSystem.current.IsPointerOverGameObject()) return;

            characterUI.gameObject.SetActive(true);
            
            characterUI.nameCharacter.text = characterAttributesSO.GetNameCharacter();
            characterUI.divisionCharacter.text = characterAttributesSO.GetDivisionCharacter().ToString();

            characterUI.trustAttribute.text = characterAttributesSO.GetStatValue(Attribute.LeadershipEnum.Trust).ToString();
            characterUI.relationAttribute.text = characterAttributesSO.GetStatValue(Attribute.LeadershipEnum.Relation).ToString();
            characterUI.influenceAttribute.text = characterAttributesSO.GetStatValue(Attribute.LeadershipEnum.Influence).ToString();
            characterUI.moraleAttribute.text = characterAttributesSO.GetStatValue(Attribute.LeadershipEnum.Morale).ToString();

            characterUI.leadershipLevels.text = GetComponent<CharacterMechanic>().GetLevelLead().ToString();

                
                
                
                
        }
    }
}
