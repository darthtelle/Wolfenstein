using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Weapon/Standard")]
public class StandardWeapon : Weapon
{
	public override void UpdateWeapon(PlayerWeapon playerWeapon, FireCallback fireCallback, FireCallback finishedFireCallback)
	{
		if(InputManager.Instance.IsShoot)
		{
			Fire(playerWeapon, fireCallback, finishedFireCallback);
		}
	}
}