using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phase2State : BossBaseState
{

    private BossHealth bossHealth;
    private Animator animator;



    public override void EnterState(BossStateManager boss)
    {
        Debug.Log("hello from phase 2");

        bossHealth = boss.GetBossHealth();
        animator = boss.GetComponent<Animator>();

        animator.SetTrigger("Phase2");
    }


    public override void UpdateState(BossStateManager boss)
    {
        //Debug.Log("Phase 2 update");
    }




    public override void ExitState(BossStateManager boss)
    {
        
    }

}
