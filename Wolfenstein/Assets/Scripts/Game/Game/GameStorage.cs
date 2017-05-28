using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStorage : Singleton<GameStorage>
{
#region Environment
	[Header("Environment")]

#endregion

#region Weapons
	[Header("Weapons")]
	
	[SerializeField]
	private Weapon m_KnifeWeapon;
	public Weapon GetKnife { get { return m_KnifeWeapon; } }

	[SerializeField]
	private Weapon m_PistolWeapon;
	public Weapon GetPistol { get { return m_PistolWeapon; } }

	[SerializeField]
	private Weapon m_MachineGunWeapon;
	public Weapon GetMachineGun { get { return m_MachineGunWeapon; } }

	[SerializeField]
	private Weapon m_ChainGunWeapon;
	public Weapon GetChainGunWeapon { get { return m_ChainGunWeapon; } }

#endregion
}
