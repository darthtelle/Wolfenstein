using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class Enemy : ScriptableObject
{
	[SerializeField]
	private int m_HP;
	public int GetHP { get { return m_HP; } }

	[SerializeField]
	private int m_Speed;
	public int GetSpeed { get { return m_Speed; } }

	[SerializeField]
	private bool m_Pain;
	public bool GetPain { get { return m_Pain; } }

	[SerializeField]
	private int m_Points;
	public int GetPoints { get { return m_Points; } }

	[SerializeField]
	private Weapon m_Weapon;
	public Weapon GetWeapon { get { return m_Weapon; } }

	[SerializeField]
	private int m_Damage;
	public int GetDamager { get { return m_Damage; } }

	[SerializeField]
	private GameObject m_DropObject;
	public GameObject GetDropObject { get { return m_DropObject; } }
}
