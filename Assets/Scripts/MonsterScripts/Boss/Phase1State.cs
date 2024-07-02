using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phase1State : BossBaseState
{
    private BossHealth bossHealth;
    private Animator animator;

    private float actionCooldown = 2.0f; // Zeit zwischen den Aktionen
    private float nextActionTime = 0.0f;

    public override void EnterState(BossStateManager boss)
    {
        Debug.Log("Phase 1 start");
        bossHealth = boss.GetBossHealth();
        animator = boss.GetComponent<Animator>();
    }

    public override void UpdateState(BossStateManager boss)
    {
        // Wenn der Boss weniger als 50% Leben hat, wechseln wir zu Phase2
        if (bossHealth != null && bossHealth.CurrentHealth <= bossHealth.MaxHealth * 0.5f)
        {
            boss.SwitchState(boss.phase2State);
            return; // Verhindert, dass weitere Aktionen ausgeführt werden
        }

        // Führe zufällige Aktionen aus, wenn die Zeit dafür gekommen ist
        if (Time.time >= nextActionTime)
        {
            SwitchToRandomActionState(boss);
            nextActionTime = Time.time + actionCooldown;
        }
    }

    private void SwitchToRandomActionState(BossStateManager boss)
    {
        int actionIndex = Random.Range(0, 4); // Zufällig eine Zahl zwischen 0 und 3 wählen

        switch (actionIndex)
        {
            case 0:
                boss.SwitchState(boss.attack1State);
                break;
            case 1:
                boss.SwitchState(boss.attack2State);
                break;
            case 2:
                boss.SwitchState(boss.idleState);
                break;
            case 3:
                boss.SwitchState(boss.moveState);
                break;
        }
    }

    public override void ExitState(BossStateManager boss)
    {
        // Logik zum Verlassen des Zustands
    }
}
