using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Leadership.Core;

namespace Leadership.Character
{
    public class SimpleMovement : MonoBehaviour
    {
        [SerializeField] Transform target;
        [SerializeField] GameManager gameManager;
        

        Animator animator;
        NavMeshAgent agent;
        bool isTouched;
        Vector3 dir;
        // Start is called before the first frame update
        void Start()
        {
            animator = GetComponent<Animator>();
            agent = GetComponent<NavMeshAgent>();
            agent.updateRotation = false;
            agent.updateUpAxis = false;
            

            
        }

        // Update is called once per frame
        void Update()
        {
            // if(!gameManager.PlayState()) 
            // {
            //     agent.isStopped = true;
            //     animator.SetBool("IsTarget", false);
            //     return;
            // }
            // if (!target) return;

            // agent.isStopped = false;
            // animator.speed = 1;
            // agent.SetDestination(target.position);

            
            // animator.SetBool("IsTarget", true);
            

            
        
            // dir = target.position - transform.position;
            // dir.Normalize();
            
            

            // animator.SetFloat("Horizontal", ( dir.x));
            // animator.SetFloat("Vertical", ( dir.y));
  

        }

       

        


        
        
    }
}
