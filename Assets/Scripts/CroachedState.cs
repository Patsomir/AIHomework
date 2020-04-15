using UnityEngine;

public class CroachedState : StateMachineBehaviour
{
	private MovementController movementController;

	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		movementController = animator.GetComponent<MovementController>();
		movementController.Croach();
	}

	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		movementController.Stand();
	}
}
