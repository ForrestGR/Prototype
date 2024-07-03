using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionState : BossBaseState
{
    private Animator animator;
    private Transform player;

    public override void EnterState(BossStateManager boss)
    {

        Debug.Log("Detection State start");
        animator = boss.GetComponent<Animator>();
        player = boss.GetPlayer();
    }

    public override void UpdateState(BossStateManager boss)
    {
        float distanceToPlayer = Vector3.Distance(boss.transform.position, player.position);

        if (distanceToPlayer <= boss.GetBossHealth().DetectionRange)
        {
            // Play the start animation
            animator.SetTrigger("StartBossFight");
            boss.SwitchState(boss.phase1State); // Switch to phase 1 (attack state) when player is detected
        }
    }

    public override void ExitState(BossStateManager boss)
    {
        Debug.Log("exiting state detecttion");
        animator.SetTrigger("Phase1");
    }
}
