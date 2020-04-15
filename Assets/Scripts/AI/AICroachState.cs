using UnityEngine;
using static UnityEngine.Mathf;
public class AICroachState : StateMachineBehaviour
{
	private MovementController movementController;
	private Transform player;

	[SerializeField]
	[Range(0.1f, 2.0f)]
	private float kickRange = 0.3f;

	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		movementController = animator.GetComponent<MovementController>();
		movementController.Croach();
		movementController.SetHorizontalMoveDirection(0);
		player = GameObject.FindWithTag("Player").transform;
	}

	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		float directionToPlayer = Sign(player.position.x - animator.transform.position.x);
		float directionOfAgent = Sign(animator.transform.localScale.x);
		float distanceToPlayer = (player.position - animator.transform.position).magnitude;
		if (distanceToPlayer < kickRange && directionToPlayer == directionOfAgent)
		{
			animator.SetTrigger("ShouldKick");
		}
	}

	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		movementController.Stand();
	}
}
