using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPhase1State : BossBaseState
{

    public override void EnterState(BossStateManager boss)
    {
        Debug.Log("Phase 1 start");
    }

    public override void ExitState(BossStateManager boss)
    {
        throw new System.NotImplementedException();
    }

    public override void UpdateState(BossStateManager boss)
    {
        throw new System.NotImplementedException();
    }
}
