using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugAnimationState : StateMachineBehaviour
{
    public string message = "Entered Animation State";

    // Called when the Animator first transitions into this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log(message + " on " + animator.gameObject.name);
    }
}

