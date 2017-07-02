using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy/State/Chase")]
public class ChaseState : EnemyState
{
	public override void StartState(EnemyStateController enemy)
	{
	}

	protected override void UpdateStateLogic(EnemyStateController enemy)
	{
		PlayerController player = (PlayerController)enemy.GetData<PlayerController>(StateData.Player);

		// Move towards the next player position.
		enemy.GetNavMeshAgent.destination = player.gameObject.transform.position;
		enemy.GetNavMeshAgent.isStopped = false;

		if(enemy.GetEnemyController.GetAnimator.IsAnimating == false)
		{
			enemy.GetEnemyController.GetAnimator.WalkForward();
		}
	}

	public override void FinishState(EnemyStateController enemy)
	{
		enemy.GetNavMeshAgent.isStopped = true;
	}
}
