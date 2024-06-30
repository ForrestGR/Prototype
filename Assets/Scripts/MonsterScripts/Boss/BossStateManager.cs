using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStateManager : MonoBehaviour
{

    BossBaseState currentState;

    public BossPhase1State phase1State = new BossPhase1State();
    public BossPhase2State phase2State = new BossPhase2State();

    private BossHealth bossHealth;


    void Start()
    {
        bossHealth = GetComponent<BossHealth>();

        //Starting state for the stsate machine
        currentState = phase1State;

        //"this" is a reference to the context (this EXACT monobrhavior script)
        currentState.EnterState(this);

        
    }


    void Update()
    {
        currentState.UpdateState(this);
    }

    public void SwitchState(BossBaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }



    public BossHealth GetBossHealth()
    {
        return bossHealth;
    }

    public void SetBossHealth(BossHealth health)
    {
        bossHealth = health;
    }
}
