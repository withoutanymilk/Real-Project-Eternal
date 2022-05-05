using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack2Bhave : StateMachineBehaviour
{
    private int rand;
    
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rand = Random.Range(0, 2);
        if(rand == 0)
        {
            animator.SetTrigger("Enrage");
        }
        else
        {
            animator.SetTrigger("Walk");
        }
    }
}
