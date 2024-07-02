using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; // Für die Navigation

public class Attack1State : BossBaseState
{
    private Animator animator;
    private NavMeshAgent navMeshAgent;
    private Transform player;

    [SerializeField] private float attackRange = 10.0f; // Reichweite des Angriffs
    private bool isAttacking = false;

    [SerializeField] private int attackDamage = 10;

    public override void EnterState(BossStateManager boss)
    {
        Debug.Log("Entering Attack 1 State");
        animator = boss.GetComponent<Animator>();
        navMeshAgent = boss.GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform; // Annahme: Der Spieler hat das Tag "Player"

        // Setze das Ziel auf den Spieler
        navMeshAgent.SetDestination(player.position);

        animator.SetTrigger("Walk");
    }

    public override void UpdateState(BossStateManager boss)
    {
        if (isAttacking) return;

        LookAtPlayer(boss);

        float distanceToPlayer = Vector3.Distance(boss.transform.position, player.position);

        if (distanceToPlayer <= attackRange)
        {
            // Stoppt die Bewegung und startet den Angriff
            Debug.Log("Attack1 wird ausgeführt"); // Debug-Ausgabe
            navMeshAgent.isStopped = true;
            animator.SetTrigger("Attack1");
            isAttacking = true;
        }
    }

    public void OnAttackHit(BossStateManager boss)
    {
        // Diese Methode wird von der Animations-Event aufgerufen, wenn der Treffer erfolgt
        float distanceToPlayer = Vector3.Distance(boss.transform.position, player.position);
        Debug.Log("OnAttackHit called, distance to player: " + distanceToPlayer); // Debug-Ausgabe

        if (distanceToPlayer <= attackRange)
        {
            // Spieler Schaden zufügen (Annahme: Spieler hat ein Script "PlayerHealth")
            PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(attackDamage); // Beispielhafter Schaden
                Debug.Log("Player took damage: " + attackDamage); // Debug-Ausgabe
            }
        }
    }

    public override void ExitState(BossStateManager boss)
    {
        // Setze den NavMeshAgent zurück
        navMeshAgent.isStopped = false;
    }

    // Diese Methode wird von der Animation aufgerufen, um den Angriff zu beenden
    public void OnAttackComplete(BossStateManager boss)
    {
        Debug.Log("Attack1 complete"); // Debug-Ausgabe
        isAttacking = false;
        boss.SwitchState(boss.phase1State);
    }

    private void LookAtPlayer(BossStateManager boss)
    {
        // Drehung zum Spieler
        Vector3 direction = (player.position - boss.transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        boss.transform.rotation = Quaternion.Slerp(boss.transform.rotation, lookRotation, Time.deltaTime * 5.0f);
    }
}
