using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Leadership.UI;


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


        private ActionDatabase actionDatabase;
        
        private SpawnActionTag[] spawnedObject;
        private DivisionEnum _divisionEnum;

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
                objectSpawn.transform.position = new Vector3(objectSpawn.transform.position.x, (objectSpawn.transform.position.y + (i - 1) * beda));

                objectSpawn.GetComponent<SpawnDescChanger>().ChangeStatus(item.GetNameAction());
                objectSpawn.GetComponent<SpawnDescChanger>().ChangeDesc(item.GetDescAction());
                

                // print(item.GetNameAction());
            }

            i=0;
        }

        public void DestroySpawn()
        {
            if(spawnedObject == null) return;
            for (int i = 0; i < spawnedObject.Length; i++)
            {
                Destroy(spawnedObject[i].gameObject);
            }
        }

        public ActionSO[] NameAction()
        {
            return actionDatabase.GetActionSO(DivisionEnum) ;
        }

        
    }
}