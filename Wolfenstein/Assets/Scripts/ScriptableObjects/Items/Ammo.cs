using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Pickup/Ammo")]
public class Ammo : Pickup
{
	[SerializeField]
	private int m_Count;

	public override void OnPickup(GameObject thisObject, Collider otherCollider)
	{
		Debug.Log("Picked up ammo: " + otherCollider);

		// Give the player some ammo.
		PlayerController playerContoller = otherCollider.gameObject.GetRequiredComponent<PlayerController>();
		playerContoller.GetWeapon.AdjustAmmo(m_Count);

		// Destroy this game object.
		Destroy(thisObject);
	}
}
