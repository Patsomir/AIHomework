using UnityEngine;

public class AIDodgeState : StateMachineBehaviour
{
	private Transform player;
	private Animator playerState;
	private float singleRoll;

	[SerializeField]
	[Range(0.1f, 2.0f)]
	private float punchRangeOfPlayer = 0.6f;

	[SerializeField]
	[Range(0.0f, 1.0f)]
	private float dodgeChance = 0.8f;
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		player = GameObject.FindWithTag("Player").transform;
		playerState = GameObject.FindWithTag("Player").GetComponent<Animator>();
		singleRoll = Random.value;
	}
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		float distanceToPlayer = (player.position - animator.transform.position).magnitude;
		if (distanceToPlayer < punchRangeOfPlayer)
		{
			if (playerState.GetCurrentAnimatorStateInfo(layerIndex).IsName("Monk_Punch")
				|| playerState.GetCurrentAnimatorStateInfo(layerIndex).IsName("Monk_Croach"))
			{
				if(singleRoll < dodgeChance)
				animator.SetTrigger("ShouldCroach");
			}
		}
	}
}
