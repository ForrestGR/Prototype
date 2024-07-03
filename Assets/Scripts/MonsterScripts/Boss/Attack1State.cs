using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Attack1State : BossBaseState
{
    private Animator animator;
    private NavMeshAgent navMeshAgent;
    private Transform player;

    [SerializeField] private float attackRange = 10.0f;
    private bool isAttacking = false;

    [SerializeField] private int attackDamage = 10;
    [SerializeField] private float attackDuration = 1.0f; // Dauer der Angriffsanimation
    [SerializeField] private float attackHitTime = 0.5f; // Zeitpunkt des Treffers während der Animation

    public override void EnterState(BossStateManager boss)
    {
        Debug.Log("Entering Attack 1 State");
        animator = boss.GetComponent<Animator>();
        navMeshAgent = boss.GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;

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
            navMeshAgent.isStopped = true;
            animator.SetTrigger("Attack1");
            isAttacking = true;
            boss.StartCoroutine(PerformAttack(boss));
        }
    }

    private IEnumerator PerformAttack(BossStateManager boss)
    {
        yield return new WaitForSeconds(attackHitTime);
        OnAttackHit(boss);

        yield return new WaitForSeconds(attackDuration - attackHitTime);
        OnAttackComplete(boss);
    }

    public void OnAttackHit(BossStateManager boss)
    {
        float distanceToPlayer = Vector3.Distance(boss.transform.position, player.position);
        Debug.Log("OnAttackHit called, distance to player: " + distanceToPlayer);

        if (distanceToPlayer <= attackRange)
        {
            PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(attackDamage);
                Debug.Log("Player took damage: " + attackDamage);
            }
        }
    }


    public void OnAttackComplete(BossStateManager boss)
    {
        Debug.Log("Attack1 complete");
        isAttacking = false;
        boss.SwitchState(boss.phase1State);
    }

    private void LookAtPlayer(BossStateManager boss)
    {
        Vector3 direction = (player.position - boss.transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        boss.transform.rotation = Quaternion.Slerp(boss.transform.rotation, lookRotation, Time.deltaTime * 5.0f);
    }


    public override void ExitState(BossStateManager boss)
    {
        navMeshAgent.isStopped = false;
        isAttacking = false;
        animator.SetTrigger("Phase1");
    }
}
