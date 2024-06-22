using UnityEngine;

public class BossController : MonoBehaviour
{
    [SerializeField] private enum BossPhase { Phase1, Phase2, Phase3 }
    [SerializeField] private BossPhase currentPhase;

    [SerializeField] private float phase2HealthThreshold = 0.7f;
    [SerializeField] private float phase3HealthThreshold = 0.3f;

    private float maxHealth = 100f;
    private float currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
        currentPhase = BossPhase.Phase1;
    }

    void Update()
    {
        CheckPhaseTransition();
        PerformAttackPattern();
    }

    void CheckPhaseTransition()
    {
        if (currentHealth <= maxHealth * phase3HealthThreshold)
        {
            currentPhase = BossPhase.Phase3;
        }
        else if (currentHealth <= maxHealth * phase2HealthThreshold)
        {
            currentPhase = BossPhase.Phase2;
        }
    }

    void PerformAttackPattern()
    {
        switch (currentPhase)
        {
            case BossPhase.Phase1:
                Phase1Attacks();
                break;
            case BossPhase.Phase2:
                Phase2Attacks();
                break;
            case BossPhase.Phase3:
                Phase3Attacks();
                break;
        }
    }

    void Phase1Attacks()
    {
        // Implement phase 1 attack patterns
    }

    void Phase2Attacks()
    {
        // Implement phase 2 attack patterns
    }

    void Phase3Attacks()
    {
        // Implement phase 3 attack patterns
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Implement death behavior
    }
}
