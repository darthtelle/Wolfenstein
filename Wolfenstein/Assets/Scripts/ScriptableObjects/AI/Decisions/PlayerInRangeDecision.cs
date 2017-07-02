using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy/Decision/Player In Range")]
public class PlayerInRangeDecision : Decision
{
	[SerializeField]
	private float m_DistanceFromPlayer;

	public override bool Decide(EnemyStateController enemy, PlayerController player)
	{
		Debug.DrawRay(enemy.GetEnemyController.transform.position, new Vector3(0.0f, 0.0f, 1.0f * m_DistanceFromPlayer), Color.red);
		Debug.DrawRay(enemy.GetEnemyController.transform.position, new Vector3(0.0f, 0.0f, -1.0f * m_DistanceFromPlayer), Color.red);
		Debug.DrawRay(enemy.GetEnemyController.transform.position, new Vector3(1.0f * m_DistanceFromPlayer, 0.0f, 0.0f), Color.red);
		Debug.DrawRay(enemy.GetEnemyController.transform.position, new Vector3(-1.0f * m_DistanceFromPlayer, 0.0f, 0.0f), Color.red);

		// Check whether the player is within the radius of the enemy.
		GameObject playerObject = IsEnemyNearPlayer(enemy);

		if((player != null) && (playerObject == player.gameObject))
		{
			return true;
		}

		return false;
	}

	private GameObject IsEnemyNearPlayer(EnemyStateController enemy)
	{
		// Get a list of colliders within the given radius of the enemy.
		Collider[] colliderList = Physics.OverlapSphere(enemy.GetEnemyController.transform.position, m_DistanceFromPlayer, Layers.GetLayerMask(Layers.Player));

		// In theory, the player should be the only thing on the player layer, so if the list is greater than 0, the player is within that radius.
		if(colliderList.Length > 0)
		{
			return colliderList[0].gameObject;
		}
		else
		{
			return null;
		}
	}
}
