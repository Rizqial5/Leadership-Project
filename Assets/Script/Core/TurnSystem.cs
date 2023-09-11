using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

namespace Leadership.Core
{
    public class TurnSystem : MonoBehaviour
    {

        private float turnTime;
        private int timeInADay;
        private int calenderTime = 1;
        private bool isPlay = false;
        private int totalWeek;

        public UnityEvent OnChangeDays;
        public UnityEvent OnChangeWeek;
        public UnityEvent OnChangeTime;


        [SerializeField] float speedModifier = 2f;
        
        [SerializeField] TextMeshProUGUI SpeedModText;

        [SerializeField] TextMeshProUGUI calenderTimeText ;
        [SerializeField] Text TimeDayText;
        
        

      

        // Start is called before the first frame update
        void Start()
        {
            calenderTimeText.text = calenderTime.ToString();
        }

        // Update is called once per frame
        void Update()
        {

            if (Input.GetKeyDown(KeyCode.L))
            {
                if (speedModifier >= 8) return;
                speedModifier += 2f;
            }
            else if (Input.GetKeyDown(KeyCode.J))
            {
                if (speedModifier == 2) return;
                speedModifier -= 2f;
            }
           
            
            // if (!isPlay) return;

            // turnTime += Time.deltaTime * SpeedModifier;

           
            // if (turnTime >= 5f)
            // {
            //     turnTime = 0f;
            //     calenderTime += 1f;
            //     OnChangeDays.Invoke();
                
            // }
            // if (calenderTime >= 8)
            // {
            //     calenderTime = 0f;
            //     isPlay = false;
            //     OnChangeWeek.Invoke();
               
            // }

            

            SpeedModText.text = speedModifier.ToString();
            calenderTimeText.text = calenderTime.ToString();
            TimeDayText.text = timeInADay.ToString();

            

        }

      

        public void Play()
        {
            if(!isPlay)
            {
                isPlay = true;
                turnTime = 0;
            } 
            else if(isPlay)
            {
                isPlay = false;
                turnTime = 0;
                

            }
        
        }

        public bool IsPlay()
        {
            return isPlay;
        }

        public int CalenderTime
        {
            get{return calenderTime;} set{calenderTime = value;}
        }
        public int ToatlWeek
        {
            get{return totalWeek;} set{totalWeek += value;}
        }

        public float TurnTime
        {
            get{return turnTime;} set{turnTime = value;}
        }

        public float SpeedModifier
        {
            get{return speedModifier;} set{speedModifier =value;}
        }

        public int ChangeTimeADay( int value)
        {
            return timeInADay += value;
        }

        public int GetTimeDay()
        {
            return timeInADay;
        }

        public float SetTimeDay(int value)
        {
            return timeInADay = value;
        }

        

        

        
    }
}

