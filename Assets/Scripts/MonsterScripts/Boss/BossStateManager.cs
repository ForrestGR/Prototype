using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStateManager : MonoBehaviour
{

    public BossBaseState currentState;

    //Phase States
    public DetectionState detectionState = new DetectionState();
    public Phase1State phase1State = new Phase1State();
    public Phase2State phase2State = new Phase2State();

    //Action States
    public IdleState idleState = new IdleState();
    public MoveState moveState = new MoveState();
    public Attack1State attack1State = new Attack1State();
    public Attack2State attack2State = new Attack2State();

    //References
    private BossHealth bossHealth;
    private Transform player;

    //Variables
    [SerializeField] public float detectionRange = 10f;


    void Start()
    {
        bossHealth = GetComponent<BossHealth>();
        bossHealth.OnHealthBelowThreshold += HandleHealthBelowThreshold;

        player = GameObject.FindGameObjectWithTag("Player").transform;

        //Starting state for the stsate machine
        currentState = detectionState;

        //"this" is a reference to the context (this EXACT monobrhavior script)
        currentState.EnterState(this); 
    }


    void Update()
    {
        currentState.UpdateState(this);
    }

    private void HandleHealthBelowThreshold()
    {
        SwitchState(phase2State);
    }

    private void OnDestroy()
    {
        if (bossHealth != null)
        {
            bossHealth.OnHealthBelowThreshold -= HandleHealthBelowThreshold;
        }
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

    public Transform GetPlayer()
    {
        return player;
    }
}
