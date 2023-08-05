using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Leadership.Management;


namespace Leadership.UI
{
    public class OutlinerMeetMechanic : MonoBehaviour
{
    [SerializeField] GameObject spawnObject;
    
    [SerializeField] Transform parentObject;
    [SerializeField] Transform firstPositionSpawn;

    [SerializeField] Image contentImage;
    [SerializeField] SpawnOutlinerTag[] spawnCount;
    
    private MeetingSystem meetingSystem;
    private TextMeshProUGUI spawnObjectEventName;
    private TextMeshProUGUI spawnObjectTimeLabel;
    private Vector3 positionSpawn;

    private string meetingNameTemp;
    private int startMeetingTemp;
    private int totalObject;
    private DivisionEnum divisionEnumTemp;

    // Start is called before the first frame update

    
    void Start()
    {
        meetingSystem = FindObjectOfType<MeetingSystem>();

        

    }

    // Update is called once per frame
    void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {

            }


            startMeetingTemp = meetingSystem.startTimeTemp;
            meetingNameTemp = meetingSystem.meetingCategoryTemp;
            divisionEnumTemp = meetingSystem.DivisionEnum;

            spawnCount = FindObjectsOfType<SpawnOutlinerTag>();

            for (int i = 0; i < spawnCount.Length; i++)
            {
                spawnCount[i].transform.position = new Vector3(transform.position.x, (firstPositionSpawn.position.y + (i - 1) * -0.3f), 0);
            }



            if (!spawnObject) return;
        
            ColourBehaviour();
            spawnObject.GetComponent<TextMeshProUGUI>().text = meetingNameTemp;
            spawnObject.GetComponentInChildren<ChildrenTag>().startMeetingTime = startMeetingTemp;
            spawnObject.GetComponentInChildren<ChildrenTag>().GetComponent<TextMeshProUGUI>().text = "Day " + startMeetingTemp ;
            spawnObject.GetComponent<SpawnOutlinerTag>().divisionName = divisionEnumTemp.ToString();



        }

        private void ColourBehaviour()
        {
            if (contentImage.IsActive() == false)
            {
                for (int i = 0; i < spawnCount.Length; i++)
                {
                    spawnCount[i].GetComponent<SpawnOutlinerTag>().ChangeToTransparent();
                }

            }
            else if (contentImage.IsActive() == true)
            {
                for (int i = 0; i < spawnCount.Length; i++)
                {
                    spawnCount[i].GetComponent<SpawnOutlinerTag>().ChangeToVisible();
                }
            }
        }

    public void SpawnOutliner()
    {
        if(meetingNameTemp == null) return ;

        
        
        if(TotalObject(divisionEnumTemp)>= meetingSystem.GetMeetingSlot()) return;
        

        positionSpawn = new Vector3(parentObject.transform.position.x,0,0);

        var OutlinerSpawn = Instantiate(spawnObject,positionSpawn,transform.rotation,parentObject);
        

    }

    public void DestoryOutliner()
    {
        if(spawnCount == null) return;
        
        for (int i = 0; i < spawnCount.Length; i++)
        {
            int meetStartTime = spawnCount[i].GetComponentInChildren<ChildrenTag>().startMeetingTime;
            
           
            if(meetingSystem.GetCalenderTime() > meetStartTime)
            {
                Destroy(spawnCount[i].gameObject);
            }
            
            
        }
    }

    private int TotalObject(DivisionEnum name)
    {
        

        for (int i = 0; i < spawnCount.Length; i++)
        {
            if(spawnCount[i].GetComponent<SpawnOutlinerTag>().divisionName == name.ToString())
            {
                return totalObject += 1;
            }
        }

        return 0;

        
    }
}
}
