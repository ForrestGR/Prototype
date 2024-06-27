using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAttack : StateMachineBehaviour
{
    public float timer;
    public float minTime;
    public float maxTime;
    public float speed;

    private Transform Player;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        timer = Random.Range(minTime, maxTime);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (timer <= 0)
        {
            animator.SetTrigger("HornAttack");
        }
        else
        {
            timer -= Time.deltaTime;
        }


        //Move Towards Player
        Vector3 target = new Vector3(Player.position.x, animator.transform.position.y, Player.position.z);
        animator.transform.position = Vector3.MoveTowards(animator.transform.position, target, speed * Time.deltaTime);

        //Look At Player
        Vector3 lookAtTarget = new Vector3(Player.position.x, animator.transform.position.y, Player.position.z);
        animator.transform.LookAt(lookAtTarget);

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

}
