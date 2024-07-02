using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Attack2State : BossBaseState
{
    private Animator animator;
    private NavMeshAgent navMeshAgent;

    private float idleDuration = 2.0f;
    private float idleTimer;

    public override void EnterState(BossStateManager boss)
    {
        Debug.Log("Entering Attack2 State");
        animator = boss.GetComponent<Animator>();
        navMeshAgent = boss.GetComponent<NavMeshAgent>();


        animator.SetTrigger("Attack2");
        idleTimer = 0f; // Reset the timer
    }

    public override void ExitState(BossStateManager boss)
    {
        idleTimer += Time.deltaTime;
        if (idleTimer >= idleDuration)
        {
            // Transition to the next state, e.g., ChaseState
            boss.SwitchState(boss.phase1State); // Assuming boss has a reference to chaseState
        }
    }

    public override void UpdateState(BossStateManager boss)
    {
        
    }
}
