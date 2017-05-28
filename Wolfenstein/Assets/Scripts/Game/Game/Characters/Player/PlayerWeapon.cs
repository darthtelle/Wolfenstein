using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : CharacterWeapon
{
	private const string k_FireTrigger = "Fire";
	private const string k_FireState = "Fire";

	[SerializeField]
	private GameObject m_WeaponObject;

	private Animator m_Animator;
	public Animator GetAnimator { get { return m_Animator; } }

	private void Awake()
	{
		m_Animator = m_WeaponObject.GetRequiredComponent<Animator>();
	}

	public override void Initialise(Weapon defaultWeapon)
	{
		base.Initialise(defaultWeapon);

		m_AmmoCount = VariableManager.Instance.GetDefaultAmmoCount; 
		GameEventManager.Instance.Trigger(GameEventManager.UI.UpdateAmmo, m_AmmoCount);
	}

	public void UpdateWeapon()
	{
		m_CurrentWeapon.UpdateWeapon(this, OnFire, OnFinishedFire);

#if UNITY_EDITOR
		if(Input.GetKeyDown(KeyCode.Alpha1))
		{
			SetCurrentWeapon(GameStorage.Instance.GetKnife);
		}
		else if(Input.GetKeyDown(KeyCode.Alpha2))
		{
			SetCurrentWeapon(GameStorage.Instance.GetPistol);
		}
		else if(Input.GetKeyDown(KeyCode.Alpha3))
		{
			SetCurrentWeapon(GameStorage.Instance.GetMachineGun);
		}
		else if(Input.GetKeyDown(KeyCode.Alpha4))
		{
			SetCurrentWeapon(GameStorage.Instance.GetChainGunWeapon);
		}
#endif
	}

#region Current Weapon

	public override void SetCurrentWeapon(Weapon weapon)
	{
		base.SetCurrentWeapon(weapon);

		m_WeaponObject.GetRequiredComponent<SpriteRenderer>().sprite = weapon.GetGameSprite;
		m_Animator.runtimeAnimatorController = weapon.GetAnimatorController;
		GameEventManager.Instance.Trigger(GameEventManager.UI.UpdateWeapon, m_CurrentWeapon);
	}

#endregion

#region Fire Weapon

	private void OnFire()
	{
		m_AmmoCount = Mathf.Max(0, m_AmmoCount - 1);
		GameEventManager.Instance.Trigger(GameEventManager.UI.UpdateAmmo, m_AmmoCount);
	}

	private void OnFinishedFire()
	{
		if(m_AmmoCount <= 0)
		{
			SetCurrentWeapon(GameStorage.Instance.GetKnife);
		}
	}

#endregion

#region Ammo

	public override void AdjustAmmo(int ammoCount)
	{
		base.AdjustAmmo(ammoCount);

		GameEventManager.Instance.Trigger(GameEventManager.UI.UpdateAmmo, m_AmmoCount);
	}

#endregion
}
