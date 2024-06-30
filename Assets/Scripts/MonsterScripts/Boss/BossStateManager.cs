using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStateManager : MonoBehaviour
{

    BossBaseState currentState;

    public BossDetectionState detectionState = new BossDetectionState();
    public BossPhase1State phase1State = new BossPhase1State();
    public BossPhase2State phase2State = new BossPhase2State();

    private BossHealth bossHealth;
    private Transform player;

    [SerializeField] public float detectionRange = 10f;


    void Start()
    {
        bossHealth = GetComponent<BossHealth>();
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
