using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieAI : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float detectionRange = 10.0f;
    //[SerializeField] private float idleSpeed = 10;
    [SerializeField] private float wanderSpeed = 10;
    [SerializeField] private float followingSpeed = 10;
    [SerializeField] private float attackDistance = 2;
    [SerializeField] private float zombieDamage = 10;
    [SerializeField] private float attackCooldown = 2.0f;
    [SerializeField] private float wanderRadius = 10.0f;

    private float lastAttackTime;
    private Vector3 randomDestination;

    private bool isWandering;
    private bool isFollowing;
    private bool isAttacking;

    private FPSPlayerHealth fpsPlayerHealth;

    private NavMeshAgent agent;
    private Animator animator;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        fpsPlayerHealth = player.GetComponent<FPSPlayerHealth>();
    }

    void Update()
    {   
        Wander();
        Follow();
        Attack();
    }



    //Methode, dass der Zombie rumläuft
    private void Wander()
    {
        if (!isFollowing && !isAttacking &&!agent.hasPath)
        {
            randomDestination = GetRandomPoint(transform.position, wanderRadius);
            agent.SetDestination(randomDestination);
            agent.speed = wanderSpeed;

            isFollowing = false;
            isAttacking = false;
            isWandering = true;
            SoundManager.Instance.PlayRandomWanderSound();
            UpdateAnimatorParameters();
        }
    }



    //Methode zum verfolgen des Spielers
    private void Follow()
    {
        float distanceToPlayer = Vector3.Distance(player.position, transform.position);
        Debug.Log(distanceToPlayer);

        if (distanceToPlayer <= detectionRange && distanceToPlayer >= attackDistance)
        {
            agent.SetDestination(player.position);
            isWandering=false;
            isFollowing = true;
            agent.speed = followingSpeed;
            lookAtPlayer();
            SoundManager.Instance.PlayFollowSound();
        }
        else
        {
            agent.ResetPath();
            isFollowing = false;
        }
        UpdateAnimatorParameters();
    }


    //Angriffs und DeamDamage Methode
    private void Attack()
    {
        float distanceToPlayer = Vector3.Distance(player.position, transform.position);

        if (distanceToPlayer < attackDistance) 
        {
            isAttacking = true;


            if (Time.time >= lastAttackTime + attackCooldown)
            {
                DealDamage();
                lastAttackTime = Time.time; // Update the last attack time
                SoundManager.Instance.PlayAttackSound();
            }
        }
        else
        {
            isAttacking = false;            
        }
        UpdateAnimatorParameters();
    }


    //DealDamage Methode für Attack();
    private void DealDamage()
    {


        if (fpsPlayerHealth != null )
        {
            fpsPlayerHealth.TakeDamage(zombieDamage);
        }
    }


    //Den Spieler angucken beim verfolgen
    private void lookAtPlayer()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * agent.angularSpeed);
    }


    //Animator Updates
    private void UpdateAnimatorParameters()
    {
        animator.SetBool("isFollowing", isFollowing);
        animator.SetBool("isWandering", isWandering);
        animator.SetBool("isAttacking", isAttacking);
    }


    // Methode, zum wander, um einen zufälligen Punkt innerhalb eines Radius zu bekommen
    private Vector3 GetRandomPoint(Vector3 center, float radius)
    {
        Vector3 randomDirection = Random.insideUnitSphere * radius;
        randomDirection += center;
        NavMeshHit hit;
        NavMesh.SamplePosition(randomDirection, out hit, radius, 1);
        return hit.position;
    }


    // Methode zum Zeichnen der Gizmos für die detectionRange
    void OnDrawGizmosSelected()
    {
        // Farbe für die Erkennungsreichweite setzen
        Gizmos.color = Color.red;
        // Kugel um den Zombie zeichnen, um die Erkennungsreichweite darzustellen
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }
}