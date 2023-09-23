using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Leadership.UI;
using Leadership.Attribute;
using System.Collections.Generic;

namespace Leadership.Action
{
    public class ActionSpawner : MonoBehaviour
    {

        [SerializeField] GameObject actionObject;
        [SerializeField] Transform spawnLocation;
        [SerializeField] Transform spawnParent;
        [SerializeField] TextMeshProUGUI descBox;

        [SerializeField] float beda = -1f;
        private Text descActionInGame;
        private int i;
        private GameObject[] listActions = new GameObject[10];


        private ActionDatabase actionDatabase;

        private SpawnActionTag[] spawnedObject;
        private DivisionEnum _divisionEnum;

        private Dictionary<string, float> actionUIEffect;

        
        private void Awake() 
        {
            actionDatabase = GetComponent<ActionDatabase>(); 
            
            
            

        }

        void Update()
        {

            spawnedObject = FindObjectsOfType<SpawnActionTag>();
            
           
        }

        public void DeleteDesc()
        {
            if (descBox.text != null)
            {
                descBox.text = "";
            }
        }

        public DivisionEnum DivisionEnum{
            get{return _divisionEnum;} set{_divisionEnum = value;}
        }



        public void SpawnAction()
        {
            // print(NameAction());


            if (NameAction() == null) return;
            
            
            

            foreach (ActionSO item in NameAction())
            {
                i += 1;
                GameObject objectSpawn = Instantiate(actionObject, spawnLocation.position, spawnLocation.rotation, spawnParent);
                listActions[i] = objectSpawn;

                objectSpawn.transform.position = new Vector3(objectSpawn.transform.position.x, (objectSpawn.transform.position.y + (i - 1) * beda));

                objectSpawn.GetComponent<SpawnDescChanger>().ChangeStatus(item.GetNameAction());
                objectSpawn.GetComponent<SpawnDescChanger>().ChangeDesc(item.GetDescAction());
                objectSpawn.GetComponent<SpawnDescChanger>().ChangeReqDesc("Persiapan Hari : " + item.GetRequirementDay() + "\n" +
                    "Dana : " + item.GetMoneyRequirement() + "\n" +
                    "Jumlah meeting : " + item.GetTotalMeetingReq());


                LeadershipEffect[] leadershipEffect = item.GetLeadershipEffects();
                OrganizationEffect[] organizationEffect = item.GetOrganizationEffects();

                
                objectSpawn.GetComponent<ActionItem>().SetActionSO(item);

                actionUIEffect = new Dictionary<string, float>();

                foreach (var item1 in leadershipEffect)
                {
                    actionUIEffect.Add(item1.GetLeadershipEnum().ToString(), item1.GetValue());
                    

                }

                foreach (var item1 in organizationEffect)
                {
                    actionUIEffect.Add(item1.GetOrganisation().ToString(), item1.GetValue());
                    
                }



                objectSpawn.GetComponent<SpawnDescChanger>().ChangeEffectDesc(actionUIEffect);
            }

            i=0;
        }

        public void DestroySpawn()
        {
            if(listActions == null) return;
            for (int i = 0; i < listActions.Length; i++)
            {
                Destroy(listActions[i]);
            }
        }

        public ActionSO[] NameAction()
        {
            return actionDatabase.GetActionSO(DivisionEnum) ;
        }

        
    }
}