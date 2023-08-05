using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Leadership.Core
{
    public class GameManager : MonoBehaviour
    {

        [SerializeField]  TurnSystem turnSystem;
        
        public  bool PlayState()
        {
            return turnSystem.IsPlay();
        }
        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            
            // print(turnSystem.IsPlay());
            
        }
    }

}
