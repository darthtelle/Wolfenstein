using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	private PlayerMovement m_Movement;
	private PlayerWeapon m_Weapon;
	private PlayerHealth m_Health;

	public PlayerWeapon GetWeapon { get { return m_Weapon; } }
	public PlayerHealth GetHealth { get { return m_Health; } }

	private void Awake()
	{
		m_Movement = gameObject.GetRequiredComponent<PlayerMovement>();
		m_Weapon = gameObject.GetRequiredComponent<PlayerWeapon>();
		m_Health = gameObject.GetRequiredComponent<PlayerHealth>();
	}

	private void Start()
	{
		m_Weapon.Initialise(GameStorage.Instance.GetPistol);
		m_Health.Initialise(VariableManager.Instance.GetMaxHealthCount);
	}

	private void Update()
	{
		m_Movement.UpdateMovement();
		m_Weapon.UpdateWeapon();
	}
}
