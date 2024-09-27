using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class OnEyeDeathAnimFinished : StateMachineBehaviour
{
    private Vector2 death_position;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
      animator.gameObject.GetComponent<AIDestinationSetter>().target = null;
      death_position = animator.gameObject.transform.position;
      
           
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        animator.gameObject.transform.position = death_position;
        
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Destroy(animator.gameObject);
    }
    
}
