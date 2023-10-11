using Leadership.Core;
using UnityEngine;
using UnityEngine.AI;

namespace Leadership.Character
{
    public class MovementSM : StateMachine
    {
        [HideInInspector]
        public StopCharacter stopCharState;
        public MoveCharacter moveCharState;
        
        
        [HideInInspector] public GameSM gameSM;
        [HideInInspector] public Vector3 dir;
        [HideInInspector] public Animator animator;
        [HideInInspector] public NavMeshAgent agent;

        [SerializeField] public Transform targetLoc;

        private TurnSystem turnSystem;

        private void Awake() 
        {
            stopCharState = new StopCharacter(this);
            moveCharState = new MoveCharacter(this);
           
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
            if(currentState == stopCharState) return;
            base.PauseButton();
            
            currentState = stopCharState;
        }

        protected override BaseState GetInitialState()
        {
            return stopCharState;

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
