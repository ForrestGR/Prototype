using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionState : BossBaseState
{
    private Transform player;

    public override void EnterState(BossStateManager boss)
    {
        Debug.Log("Detection State start");
        player = boss.GetPlayer();
    }

    public override void UpdateState(BossStateManager boss)
    {
        float distanceToPlayer = Vector3.Distance(boss.transform.position, player.position);

        if (distanceToPlayer <= boss.GetBossHealth().DetectionRange)
        {
            boss.SwitchState(boss.phase1State); // Switch to phase 1 (attack state) when player is detected
        }
    }

    public override void ExitState(BossStateManager boss)
    {
        //throw new System.NotImplementedException();
    }
}
