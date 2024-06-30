using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPhase2State : BossBaseState
{
    public override void EnterState(BossStateManager boss)
    {
        Debug.Log("hello from phase 2");
    }


    public override void UpdateState(BossStateManager boss)
    {
        Debug.Log("Phase 2 update");
    }




    public override void ExitState(BossStateManager boss)
    {
        throw new System.NotImplementedException();
    }

}
