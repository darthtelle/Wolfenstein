using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy/Decision/Player Visible")]
public class PlayerVisibleDecision : Decision
{
	private const float k_MaxDistance = 20.0f;

	[SerializeField]
	private float m_ViewingAngle;

	public override bool Decide(EnemyStateController enemy, PlayerController player)
	{
		if(player != null)
		{
			Debug.DrawRay(enemy.GetEnemyController.transform.position, enemy.GetEnemyController.transform.forward * k_MaxDistance, Color.green);
			Debug.DrawRay(enemy.GetEnemyController.transform.position, Quaternion.Euler(0.0f, m_ViewingAngle * 0.5f, 0.0f) * enemy.GetEnemyController.transform.forward * k_MaxDistance, Color.green);
			Debug.DrawRay(enemy.GetEnemyController.transform.position, Quaternion.Euler(0.0f, -m_ViewingAngle * 0.5f, 0.0f) * enemy.GetEnemyController.transform.forward * k_MaxDistance, Color.green);

			// Check whether the player is in the enemy's field of vision.
			if(IsPlayerInEnemyFieldOfVision(enemy, player.gameObject))
			{
				// Check whether the enemy doesn't have their view of the player blocked.
				if(CanEnemySeePlayer(enemy, player.gameObject))
				{
					return true;	
				}
			}
			
		}

		return false;
	}

	private bool CanEnemySeePlayer(EnemyStateController enemy, GameObject playerObject)
	{
		Vector3 directionToPlayer = (playerObject.transform.position - enemy.GetEnemyController.transform.position).normalized;
		RaycastHit hit;

		Debug.DrawLine(enemy.GetEnemyController.transform.position, playerObject.transform.position, Color.blue);

		// Raycast from the enemy in the direction of the player.
		if(Physics.Raycast(enemy.GetEnemyController.transform.position, directionToPlayer, out hit, k_MaxDistance, ~(1 << LayerMask.NameToLayer(Layers.Enemy))))
		{
			// Check if what we hit was the player.
			if(hit.collider.gameObject == playerObject)
			{
				return true;
			}
		}

		return false;
	}

	private bool IsPlayerInEnemyFieldOfVision(EnemyStateController enemy, GameObject playerObject)
	{
		Vector3 directionToPlayer = (playerObject.transform.position - enemy.GetEnemyController.transform.position).normalized;
		float angle = Vector3.Angle(enemy.GetEnemyController.transform.forward, directionToPlayer);

		return(angle < (m_ViewingAngle * 0.5f));
	}
}
