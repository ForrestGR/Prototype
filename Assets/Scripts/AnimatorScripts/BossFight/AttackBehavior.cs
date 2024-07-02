//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class AttackBehavior : StateMachineBehaviour
//{

//    public float timer;
//    public float minTime;
//    public float maxTime;
//    public float speed;

//    private Transform playerPos;

//    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
//    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
//    {
//        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
//        timer = Random.Range(minTime, maxTime);
//    }

//    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
//    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
//    {
//        if (timer <= 0)
//        {
//            animator.SetTrigger("idle1");
//        }
//        else
//        {
//            timer -= Time.deltaTime;
//        }

//        Vector3 target = new Vector3(playerPos.position.x, animator.transform.position.y, playerPos.position.z);
//        animator.transform.position = Vector3.MoveTowards(animator.transform.position, target, speed * Time.deltaTime);

//        Vector3 lookAtTarget = new Vector3(playerPos.position.x, animator.transform.position.y, playerPos.position.z);
//        animator.transform.LookAt(lookAtTarget);

//    }

//    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
//    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
//    {

//    }


//    // OnStateMove is called right after Animator.OnAnimatorMove()
//    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
//    //{
//    //    // Implement code that processes and affects root motion
//    //}

//    // OnStateIK is called right after Animator.OnAnimatorIK()
//    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
//    //{
//    //    // Implement code that sets up animation IK (inverse kinematics)
//    //}
//}
