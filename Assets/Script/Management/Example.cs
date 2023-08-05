using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Leadership.Management
{
    public class Example : MonoBehaviour
    {

        [SerializeField] Text totalPlan;
        [SerializeField] Text totalFixBuild;

        private float totalNumbers;
        private float totalFixNumber;
        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
          
        }

        public void Build()
        {
            if(totalFixNumber == 0) return;
            print("Building Has Constructed " + totalFixNumber );
            totalFixNumber -= 1;
            totalFixBuild.text = "Total " + totalFixNumber.ToString() ;
           
        }

        public void AddNumbers()
        {
            totalNumbers += 1;
            totalPlan.text = totalNumbers.ToString();
        }

        public void BuildButton()
        {
            totalFixNumber = totalNumbers;
            totalFixBuild.text = "Total " + totalFixNumber.ToString() ;
            print(totalFixNumber);
        }

        
    }
}

