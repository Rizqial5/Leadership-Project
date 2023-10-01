using System.Collections;
using System.Collections.Generic;
using Leadership.Core;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.AI;

namespace Leadership.Character
{
    public class MovementSM : StateMachine
    {
        [HideInInspector]
        public PlanCharacter planCharState;
        public MoveCharacter moveCharState;
        public PauseCharacter pauseCharState;
        
        [HideInInspector] public GameSM gameSM;
        [HideInInspector] public Vector3 dir;
        [HideInInspector] public Animator animator;
        [HideInInspector] public NavMeshAgent agent;

        [SerializeField] public Transform targetLoc;

        private TurnSystem turnSystem;

        private void Awake() 
        {
            planCharState = new PlanCharacter(this);
            moveCharState = new MoveCharacter(this);
            pauseCharState = new PauseCharacter(this);

            gameSM = FindObjectOfType<GameSM>();
            animator = GetComponent<Animator>();
            agent = GetComponent<NavMeshAgent>();

            turnSystem = FindObjectOfType<TurnSystem>();

            
        }

        public override void PlayButton()
        {
            currentState = moveCharState;
            base.PlayButton();
            
        }

        public override void PauseButton()
        {
            if(currentState == planCharState) return;
            base.PauseButton();
            
            currentState = pauseCharState;
        }

        protected override BaseState GetInitialState()
        {
            return planCharState;

        }

        public void SetTransfromTarget(Transform target)
        {
            targetLoc = target;
        }

        public float  GetSpeedModifier()
        {
            return turnSystem.SpeedModifier;
        }

        // public bool IsThereTarget()
        // {
        //     return target != null;
        // }

        // private void OnGUI() 
        // {
        //     string content = currentState != null ? currentState.name : "(no current state)";
        //     GUILayout.Label($"<color='blue'><size=40>{content}</size></color>");    
        // }

    }
}
