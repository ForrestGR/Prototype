using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChillingBehavior : StateMachineBehaviour
{
    [SerializeField] private float detectionRange = 5.0f;
    private Transform Player;
    private Transform bossTransform;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        bossTransform = animator.transform;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Vector3.Distance(Player.position, bossTransform.position) <= detectionRange)
        {
            animator.SetTrigger("startBossFight");
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    // Draw a gizmo to show the detection range in the editor
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(bossTransform.position, detectionRange);
    }
}
