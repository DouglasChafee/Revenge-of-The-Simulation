using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_jump : StateMachineBehaviour
{
    public float speed;
    public float attackRange = 3f;

    private Transform player;
    private Rigidbody2D rb;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rb = animator.GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        Vector2 target = new Vector2(player.position.x, animator.transform.position.y);
        Vector2 newPos = Vector2.MoveTowards(animator.transform.position, target, speed * Time.deltaTime);
        newPos.y = newPos.y + 8;
        animator.GetComponent<Rigidbody2D>().MovePosition(newPos);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Vector2.Distance(player.position, rb.position) <= attackRange)
        {
            animator.SetTrigger("Attack");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
   override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

}
