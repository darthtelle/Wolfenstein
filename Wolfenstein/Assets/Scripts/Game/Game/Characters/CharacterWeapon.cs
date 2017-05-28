using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterWeapon : MonoBehaviour
{
	protected Weapon m_CurrentWeapon;

	protected int m_AmmoCount;

	public virtual void Initialise(Weapon defaultWeapon)
	{
		SetCurrentWeapon(defaultWeapon);
	}

#region Current Weapon

	public virtual void SetCurrentWeapon(Weapon weapon)
	{
		m_CurrentWeapon = weapon;
	}

#endregion

#region Ammo

	public virtual void AdjustAmmo(int ammoCount)
	{
		m_AmmoCount = Mathf.Max(0, Mathf.Min(m_AmmoCount + ammoCount, VariableManager.Instance.GetMaxAmmoCount));
	}

#endregion
}
