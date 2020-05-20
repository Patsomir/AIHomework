using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtState : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<MonkEvents>().OnTakeDamage?.Invoke();
    }
}
