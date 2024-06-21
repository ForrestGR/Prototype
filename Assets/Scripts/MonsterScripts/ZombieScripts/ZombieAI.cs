using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieAI : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float detectionRange = 10.0f;
    [SerializeField] private float idleSpeed = 10;
    [SerializeField] private float followingSpeed = 10;
    [SerializeField] private float walkingSpeed = 10;
    [SerializeField] private float attackDistance = 2;

    private bool isFollowing;
    private bool isWalking;
    private bool isAttacking;


    private NavMeshAgent agent;
    private Animator animator;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {        
        follow();
        attack();
        die();
        Debug.Log("is follwing" + isFollowing);
        Debug.Log("is attacking" + isAttacking);
    }

        
    private void follow()
    {
        float distanceToPlayer = Vector3.Distance(player.position, transform.position);
        Debug.Log(distanceToPlayer);

        if (distanceToPlayer <= detectionRange && distanceToPlayer >= attackDistance)
        {
            agent.SetDestination(player.position);
            isFollowing = true;
            agent.speed = followingSpeed;
            lookAtPlayer();
        }
        else
        {
            agent.ResetPath();
            isFollowing = false;
        }
        UpdateAnimatorParameters();
        isWalking = agent.velocity.magnitude > 0.1f;
    }


    private void attack()
    {
        float distanceToPlayer = Vector3.Distance(player.position, transform.position);

        if (distanceToPlayer < attackDistance) 
        {
            dealDamage();
            isAttacking = true;            
        }
        else
        {
            isAttacking = false;            
        }
        UpdateAnimatorParameters();
    }


    private void die()
    {

    }

    private void dealDamage()
    {

    }

    private void lookAtPlayer()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * agent.angularSpeed);
    }

    private void UpdateAnimatorParameters()
    {
        animator.SetBool("isFollowing", isFollowing);
        animator.SetBool("isWalking", isWalking);
        animator.SetBool("isAttacking", isAttacking);
    }

    // Methode zum Zeichnen der Gizmos
    void OnDrawGizmosSelected()
    {
        // Farbe für die Erkennungsreichweite setzen
        Gizmos.color = Color.red;
        // Kugel um den Zombie zeichnen, um die Erkennungsreichweite darzustellen
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }
}