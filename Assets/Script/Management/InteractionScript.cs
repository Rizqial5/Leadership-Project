using System.Collections;
using System.Collections.Generic;
using Leadership.Action;
using Leadership.UI;
using UnityEngine;
using UnityEngine.UI;

namespace Leadership.Management
{
    public class InteractionScript : MonoBehaviour
    {
        [SerializeField] GameObject[] gameobjectMenu;
        [SerializeField] GameObject[] actionMenu;

        private MeetingSystem _meetingSystem;
        
        private DivisionEnum _divisionEnum;
        private ActionSpawner _actionSpawner;
        

        private void Awake() {
            _meetingSystem = FindObjectOfType<MeetingSystem>();
            _actionSpawner = FindObjectOfType<ActionSpawner>();
        }
        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
           
        }

        public DivisionEnum SetDivisionEnum(DivisionEnum value)
        {
            return _divisionEnum = value;
        }

        

        public void ShowMenu()
        {
            
            
            foreach (GameObject item in gameobjectMenu)
            {
                if(item.activeInHierarchy == true)
                {
                    item.SetActive(false);
                    continue;
                }
                item.SetActive(true);
                
            }

            _meetingSystem.DivisionEnum = _divisionEnum;
        }

        public void ShowActionMenu()
        {

            
            foreach (GameObject item in actionMenu)
            {
                if(item.activeInHierarchy == true)
                {
                    item.SetActive(false);
                    continue;
                }
                item.SetActive(true);
                
            }
            _actionSpawner.DivisionEnum = _divisionEnum;
            
        }

       

        
    }
}
