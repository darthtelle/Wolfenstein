using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy/State/Patrol")]
public class PatrolState : EnemyState
{
	public override void StartState(EnemyStateController enemy)
	{
		int closestIndex = 0;
		float distance = 999.0f;

		// Find closest point on the patrol.
		for(int patrolIndex = 0; patrolIndex < enemy.GetPatrolList.Length; patrolIndex++)
		{
			float distanceToPatrol = Vector3.Distance(enemy.GetEnemyController.transform.position, enemy.GetPatrolList[patrolIndex].transform.position);
			if(distanceToPatrol < distance)
			{
				closestIndex = patrolIndex;
				distance = distanceToPatrol;
			}
		}

		enemy.SetData(StateData.PatrolIndex, (int)closestIndex);
	}

	protected override void UpdateStateLogic(EnemyStateController enemy)
	{
		int patrolIndex = enemy.GetData<int>(StateData.PatrolIndex);

		// Move towards the next position on the patrol path.
		enemy.GetNavMeshAgent.destination = enemy.GetPatrolList[patrolIndex].transform.position;
		enemy.GetNavMeshAgent.isStopped = false;

		if(enemy.GetEnemyController.GetAnimator.IsAnimating == false)
		{
			enemy.GetEnemyController.GetAnimator.WalkForward();
		}

		// Check whether the enemy has reached it's destination.
		if((enemy.GetNavMeshAgent.remainingDistance <= enemy.GetNavMeshAgent.stoppingDistance) && (enemy.GetNavMeshAgent.pathPending == false))
		{
			patrolIndex = (patrolIndex + 1) % enemy.GetPatrolList.Length;
			enemy.SetData(StateData.PatrolIndex, patrolIndex);
		}
	}

	public override void FinishState(EnemyStateController enemy)
	{
		enemy.GetNavMeshAgent.isStopped = true;
	}
}
