using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Weapon/Automatic")]
public class AutomaticWeapon : Weapon
{
	public override void UpdateWeapon(PlayerWeapon playerWeapon, FireCallback fireCallback, FireCallback finishedFireCallback)
	{
		if(InputManager.Instance.IsShoot)
		{
			Fire(playerWeapon, fireCallback, finishedFireCallback);
		}
	}
}