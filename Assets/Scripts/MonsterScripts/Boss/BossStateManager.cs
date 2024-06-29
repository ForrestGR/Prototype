using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStateManager : MonoBehaviour
{

    BossBaseState currentState;

    BossPhase1State phase1State = new BossPhase1State();
    BossPhase2State phase2State = new BossPhase2State();


    void Start()
    {
        currentState = phase1State;

        currentState.EnterState(this);
    }


    void Update()
    {
        currentState.UpdateState(this);
    }
}
