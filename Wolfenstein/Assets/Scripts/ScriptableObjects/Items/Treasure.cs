using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Pickup/Treasure")]
public class Treasure : Pickup
{
	[SerializeField]
	private int m_Score;

	public override void OnPickup(GameObject thisObject, Collider otherCollider)
	{
		Debug.Log("Picked up treasure: " + otherCollider);

		// Destroy this game object.
		Destroy(thisObject);
	}
}
