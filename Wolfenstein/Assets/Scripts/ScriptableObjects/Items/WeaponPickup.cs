using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Pickup/Weapon")]
public class WeaponPickup : Pickup
{
	[SerializeField]
	private Weapon m_Weapon;

	[SerializeField]
	private int m_AmmoCount;

	public override void OnPickup(GameObject thisObject, Collider otherCollider)
	{
		Debug.Log("Picked up weapon: " + m_Weapon);

		// Give the player some ammo and update the current ammo.
		PlayerController playerContoller = otherCollider.gameObject.GetRequiredComponent<PlayerController>();
		playerContoller.GetWeapon.AdjustAmmo(m_AmmoCount);
		playerContoller.GetWeapon.SetCurrentWeapon(m_Weapon);

		// Destroy this game object.
		Destroy(thisObject);
	}
}
