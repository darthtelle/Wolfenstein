using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VariableManager : Singleton<VariableManager>
{
#region Player
	[Header("Player")]

	[SerializeField]
	private int m_DefaultAmmoCount;
	public int GetDefaultAmmoCount { get { return m_DefaultAmmoCount; } }

	[SerializeField]
	private int m_MaxAmmoCount;
	public int GetMaxAmmoCount { get { return m_MaxAmmoCount; } }

	[SerializeField]
	private int m_MaxHealthCount;
	public int GetMaxHealthCount { get { return m_MaxHealthCount; } }

#endregion
}
