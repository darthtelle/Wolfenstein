using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Pickup/Health")]
public class Health : Pickup
{
	[SerializeField]
	private int m_Amount;

	public override void OnPickup(GameObject thisObject, Collider otherCollider)
	{
		Debug.Log("Picked up health: " + otherCollider);

		// Give the player some health.
		PlayerController playerContoller = otherCollider.gameObject.GetRequiredComponent<PlayerController>();
		playerContoller.GetHealth.AdjustHealth(m_Amount);

		// Destroy this game object.
		Destroy(thisObject);
	}
}
