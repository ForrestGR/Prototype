using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveState : BossBaseState
{
    //Variables
    private float moveDuration = 5.0f;
    private float moveTimer;

    //References
    private Animator animator;
    private NavMeshAgent navMeshAgent;
    private Transform player;

    // Movement action
    private System.Action currentMovement;

    public override void EnterState(BossStateManager boss)
    {
        // Debug
        Debug.Log("Entering Move State");

        // Set References
        animator = boss.GetComponent<Animator>();
        navMeshAgent = boss.GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;

        // Animator
        animator.SetTrigger("Walk");

        // Variables
        moveTimer = 0f; // Reset the timer

        // Select a random movement
        SelectRandomMovement();
    }

    public override void UpdateState(BossStateManager boss)
    {
        moveTimer += Time.deltaTime;
        if (moveTimer >= moveDuration)
        {
            boss.SwitchState(boss.phase1State);
        }

        LookAtPlayer();
        currentMovement?.Invoke();
    }

    private void SelectRandomMovement()
    {
        int actionIndex = Random.Range(0, 4); // Adjusted to include 3 as well

        switch (actionIndex)
        {
            case 0:
                currentMovement = WalkRight;
                break;
            case 1:
                currentMovement = WalkLeft;
                break;
            case 2:
                currentMovement = WalkForward;
                break;
            case 3:
                currentMovement = WalkBackward;
                break;
        }
    }

    private void WalkRight()
    {
        Debug.Log("Walking Right");
        animator.SetTrigger("WalkRight");
        navMeshAgent.Move(Vector3.right * navMeshAgent.speed * Time.deltaTime);
    }

    private void WalkLeft()
    {
        Debug.Log("Walking Left");
        animator.SetTrigger("WalkLeft");
        navMeshAgent.Move(Vector3.left * navMeshAgent.speed * Time.deltaTime);
    }

    private void WalkForward()
    {
        Debug.Log("Walking Forward");
        animator.SetTrigger("WalkForward");
        navMeshAgent.Move(Vector3.forward * navMeshAgent.speed * Time.deltaTime);
    }

    private void WalkBackward()
    {
        Debug.Log("Walking Backward");
        animator.SetTrigger("WalkBackward");
        navMeshAgent.Move(Vector3.back * navMeshAgent.speed * Time.deltaTime);
    }


    private void LookAtPlayer()
    {
        Vector3 direction = (player.position - navMeshAgent.transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        navMeshAgent.transform.rotation = Quaternion.Slerp(navMeshAgent.transform.rotation, lookRotation, Time.deltaTime * 5f);
    }


    public override void ExitState(BossStateManager boss)
    {
        animator.SetTrigger("Walk");
        animator.SetTrigger("Phase1");
    }
}
