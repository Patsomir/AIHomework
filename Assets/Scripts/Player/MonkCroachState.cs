using static Controlls;
using UnityEngine;

public class MonkCroachState : StateMachineBehaviour
{
	private MovementController movementController;

	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		movementController = animator.GetComponent<MovementController>();
		movementController.Croach();
		movementController.SetHorizontalMoveDirection(0);
	}

	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		if (Input.GetKeyDown(attackKey))
		{
			animator.SetTrigger("IsKicking");
		}
		if (!Input.GetKey(croachKey))
		{
			animator.SetBool("IsCroaching", false);
		}
	}

	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		movementController.Stand();
	}
}
