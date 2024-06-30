using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPhase1State : BossBaseState
{

    private BossHealth bossHealth;
    private Animator animator;

    public override void EnterState(BossStateManager boss)
    {
        Debug.Log("Phase 1 start");
        bossHealth = boss.GetBossHealth();
        animator = boss.GetComponent<Animator>();

        // Play the start animation
        animator.SetTrigger("StartBossFight");
    }


    public override void UpdateState(BossStateManager boss)
    {
        Debug.Log("update state" + bossHealth.CurrentHealth);
        if (bossHealth != null && bossHealth.CurrentHealth <= bossHealth.MaxHealth * 0.5f)
        {
            boss.SwitchState(boss.phase2State);
        }




    }


    public override void ExitState(BossStateManager boss)
    {
        //throw new System.NotImplementedException();
    }

}
