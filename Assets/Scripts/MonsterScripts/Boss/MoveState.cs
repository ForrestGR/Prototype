using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveState : BossBaseState
{
    private Animator animator;
    private NavMeshAgent navMeshAgent;
    private float moveDuration = 2.0f;
    private float moveTimer;


    public override void EnterState(BossStateManager boss)
    {
        Debug.Log("Entering Move State");
        animator = boss.GetComponent<Animator>();
        navMeshAgent = boss.GetComponent<NavMeshAgent>();

        animator.SetTrigger("Walk");
        moveTimer = 0f; // Reset the timer
    }

    public override void ExitState(BossStateManager boss)
    {
        moveTimer += Time.deltaTime;
        if (moveTimer >= moveDuration)
        {
            boss.SwitchState(boss.phase1State);
        }
    }

    public override void UpdateState(BossStateManager boss)
    {
        
    }
}
